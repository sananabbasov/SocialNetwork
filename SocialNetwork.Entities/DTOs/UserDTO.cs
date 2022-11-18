namespace SocialNetwork.Entities.DTOs
{
    public class UserDTO
    {
        public record LoginDTO(string Email, string Password);
        public record RegisterDTO(string Name, string Surname, string UserName, string Password, DateTime BirthDay);
    }
}