using AhmadDAL.DataAccessLayer.Chats;
using AhmadDAL.DataAccessLayer.Drive;
using AhmadDAL.Models.AIChatMessage;
using AhmadDAL.Models.Chats;
using AhmadDAL.Models.Credentials;
using AhmadProfileSmarter.Interfaces;
using AhmadProfileSmarter.UnitofWork;
using AhmadService.dto.Chats;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AhmadService.Services.Chats
{
    public class ChatsService
    {
        //private readonly IChats repository;
        private readonly IUnitOfWork _unitOfWork;

        public ChatsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<List<User>> GetAllUsers()
        {
            // 🔹 Begin transaction (optional for read)
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                // 🔹 Call repository via UnitOfWork
                var users = await _unitOfWork.Chats.GetAllUsers();

               

                // 🔹 Commit transaction
                await _unitOfWork.CommitTransactionAsync();

                return users;
            }
            catch
            {
                // 🔹 Rollback if anything goes wrong
                await _unitOfWork.RollbackTransactionAsync();
                throw; // bubble up exception
            }
        }

        public async Task<AhmadDAL.Models.Chats.Chats> SendChat(string ChatText,int SenderID,int ReceiverID, DateTime MessageDate)
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                var chat = await _unitOfWork.Chats.SendChat(ChatText, SenderID, ReceiverID, MessageDate);

                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitTransactionAsync();

                return chat;
            }
            catch
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw;
            }
        }


        public async Task<List<ChatsDto>> GetMessages(int senderId, int receiverId)
        {

            // 🔹 Begin transaction (optional for read-only)
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                // 🔹 Call repository via UnitOfWork
                var chats = await _unitOfWork.Chats.GetMessages(senderId, receiverId);

                // 🔹 Map to DTO and sort
                var chatDtos = chats
                    .OrderBy(c => c.MessageDate)
                    .Select(c => new ChatsDto
                    {
                        ChatID = c.ChatID,
                        ChatText = c.ChatText,
                        SenderID = c.SenderID,
                        ReceiverID = c.ReceiverID,
                        MessageDate = c.MessageDate
                    })
                    .ToList();

                // 🔹 Commit (even for read, keeps pattern consistent)
                await _unitOfWork.CommitTransactionAsync();

                return chatDtos;
            }
            catch
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw;
            }
        }

        public async Task<AIChatMessage> AIresponse(string text)
        {
            // 🔹 Begin transaction (optional for read-only, but keeps pattern consistent)
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                // 🔹 Call repository via UnitOfWork
                var response = await _unitOfWork.Chats.AIresponse(text);

                // 🔹 Commit transaction
                await _unitOfWork.CommitTransactionAsync();

                return response;
            }
            catch
            {
                // 🔹 Rollback on error
                await _unitOfWork.RollbackTransactionAsync();
                throw; // bubble up exception
            }
        }

    }
}
