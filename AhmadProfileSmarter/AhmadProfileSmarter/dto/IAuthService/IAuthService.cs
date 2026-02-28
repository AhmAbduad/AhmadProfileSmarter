namespace AhmadService.dto.IAuthService
{
    public interface IAuthService
    {
        string GenerateJwtToken(AhmadDAL.Models.Credentials.User user);
    }
}
