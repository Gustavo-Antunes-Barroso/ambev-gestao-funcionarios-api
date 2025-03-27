using Ambev.GestaoFuncionarios.Application.Services.Rsa;

namespace Ambev.GestaoFuncionarios.UnitTest.Application.Services.Rsa
{
    public class RsaServiceTest
    {
        private readonly RsaService _service;
        private readonly string _fakePemPath = "RsaKey.pem";
        private readonly string _fakePemContent = "-----BEGIN RSA PRIVATE KEY-----\r\nMIICWgIBAAKBgFYO+UyKHyALDP87FgERUDPm4D/vcxdh2q6YVSsmJQ4S5LkoclnE\r\nzsEbzS0NyRVLbEDeaVmVZFjRFmdFYPIwwZvp30m9yg0xLD7scDoMzsqSsu30ATRP\r\noLWvu0x73xjOucDlbhqea57/gYWjdKTMyFjbquJTdYvwG/zmPXube9KhAgMBAAEC\r\ngYAciXKZsuOHWKLCr/EoAXm6/EA4c0qS4lwFsXXsjQWUmSdHTuY8Zkq5NmLfIccg\r\nTJZlHFuK3UMdQJhRPmxbY1eP3WVt9syIYh1LsjG2Pri3nfOK8jdw6kxOK1qrXodm\r\naCioUk91d9sk8HFAkUQkR0VW3bxrpZmQDlnNK+QFn44MkQJBAJ5EMXXzuwzvGKxa\r\nBgVWIXalPj/h2oshb3GQEtGVG/kG47+84Yr9GXoeen5l0dEEphs5siM6WD7Q+IM/\r\nV+RUx88CQQCLM6zYdunh0+kMVT5v/pf5SgkpqEo+qd1n9DRrupeUiyLxfIvHU5tj\r\nq7CZPwJYbeppI2CymLbr1zQBKJ+Y8+qPAkBlBBWluYl8Oee/qj4Jje4R8mqHD7sT\r\n7qVZEKJSTx/plLItIXu74MwwG+AHaSnAhX0YB31h6s2EWpEkBHwu6sYVAkAg1LpC\r\nf6Ff6tv/VaeZQIHVgPmyQofoSaX3m6g1dFfF6B8At7A7/eMbWeYX7r1938a2r2pi\r\nFRSngSU51Lv3lifPAkBYJ27JjY/RmpPncgmv7m1n/3pQKGPnDGZR0Bnsw1G8QG4g\r\n5FI/ZfylCCf6flcj81MlbpNZSsItcxsH3sNPSnOY\r\n-----END RSA PRIVATE KEY-----";

        public RsaServiceTest()
        {
            // Garantir que o arquivo PEM seja simulado nos testes
            File.WriteAllText(_fakePemPath, _fakePemContent);

            // Instância da classe sob teste
            _service = new RsaService();
        }

        [Fact]
        public void Encrypt_Success()
        {
            string plainText = "SenhaEncrypt";
            string encryptedData;

            encryptedData = _service.Encrypt(plainText);

            Assert.NotNull(encryptedData);
            Assert.NotEqual(plainText, encryptedData);
        }

        [Fact]
        public void Decrypt_Success()
        {
            string plainText = "SenhaDecrypt";
            string encryptedData = _service.Encrypt(plainText);

            string decryptedData = _service.Decrypt(encryptedData);

            Assert.Equal(plainText, decryptedData);
        }
    }
}
