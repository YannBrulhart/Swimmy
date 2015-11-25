namespace Swimmy.Services.Contracts
{
    public interface IEncryptionService
    {
        string CreateSalt();

        string EncryptPassword(
            string password,
            string salt);
    }
}