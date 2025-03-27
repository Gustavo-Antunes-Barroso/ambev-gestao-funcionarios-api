using Ambev.GestaoFuncionarios.Domain.Services.Rsa;
using System.Security.Cryptography;
using System.Text;

namespace Ambev.GestaoFuncionarios.Application.Services.Rsa
{
    public class RsaService : IRsaService
    {
        public string Decrypt(string base64EncryptedData)
        {
            var encryptedBytes = Convert.FromBase64String(base64EncryptedData);
            using var rsa = ReadFilePem();
            var decryptedBytes = rsa.Decrypt(encryptedBytes, RSAEncryptionPadding.Pkcs1);
            return Encoding.UTF8.GetString(decryptedBytes);
        }

        public string Encrypt(string data)
        {
            var dataBytes = Encoding.UTF8.GetBytes(data);
            using var rsa = ReadFilePem();
            var encryptedBytes = rsa.Encrypt(dataBytes, RSAEncryptionPadding.Pkcs1);
            return Convert.ToBase64String(encryptedBytes);
        }

        private RSA ReadFilePem()
        {
            var rsa = RSA.Create();
            rsa.ImportFromPem(File.ReadAllText("RsaKey.pem"));
            return rsa;
        }
    }
}
