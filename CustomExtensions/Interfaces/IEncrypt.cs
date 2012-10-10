namespace CustomExtensions.Interfaces
{
    public interface IEncrypt : IAESCrypto
    {
        string EncryptAES(string source, string password);
    }
}