namespace SimplyKnowHau.Application.Interfaces
{
    public interface IPasswordHasher
    {
        string Hash(string email, string password);
        bool Verify(string passwordHash, string email, string password);
    }
}