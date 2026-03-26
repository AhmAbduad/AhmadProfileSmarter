using AhmadDAL.Data;
using AhmadDAL.Models.Meetings;
using AhmadDAL.Models.ParticipantFiles;
using AhmadProfileSmarter.Interfaces;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.EntityFrameworkCore;

namespace AhmadProfileSmarter.DataAccessLayer.CollaboratedFiles
{
    public class CollaboratedFilesRepository : ICollaboratedFiles
    {

        private readonly AppDbContext _context;

        public CollaboratedFilesRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ParticipantFiles>> GetFilesDocx()
        {
            return await _context.ParticipantFiles
            .Where(f =>
                f.ContentType == "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                || (f.ActualFileName != null && f.ActualFileName.EndsWith(".docx"))
            )
            .ToListAsync();
        }

        public async Task<ParticipantFiles> UpdateFileDoc(int id, string content)
        {
            // 🔍 Find file by ID
            var file = await _context.ParticipantFiles
                .FirstOrDefaultAsync(f => f.ParticipantFilesID == id);

            if (file == null)
                throw new Exception("File not found");

            // 🔄 Convert string → DOCX byte[]
            var fileBytes = GenerateDocxFromText(content);
            file.ActualFile = fileBytes;


            // 🕒 Update date
            file.UploadDate = DateTime.Now;

            file.Size = $"{fileBytes.Length / 1024} KB";

            return file;
        }



        public byte[] GenerateDocxFromText(string text)
        {
            using (var stream = new MemoryStream())
            {
                using (var wordDoc = WordprocessingDocument.Create(
                    stream,
                    DocumentFormat.OpenXml.WordprocessingDocumentType.Document,
                    true))
                {
                    var mainPart = wordDoc.AddMainDocumentPart();
                    mainPart.Document = new Document();
                    var body = mainPart.Document.AppendChild(new Body());

                    body.AppendChild(new Paragraph(
                        new Run(
                            new Text(text)
                        )
                    ));

                    mainPart.Document.Save();
                }

                return stream.ToArray();
            }
        }
    }
}
