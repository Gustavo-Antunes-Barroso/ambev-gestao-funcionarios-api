namespace Ambev.GestaoFuncionarios.Domain.Services.Rsa
{
    public interface IRsaService
    {
        string Decrypt(string base64EncryptedData);
        string Encrypt(string data);
    }
}
