namespace CustomExtensions.Interfaces
{
    public interface IDecrypt : IAESCrypto
    {
        string DecryptAES(string source, string password);
    }
}