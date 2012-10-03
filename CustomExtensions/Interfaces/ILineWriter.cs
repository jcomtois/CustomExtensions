namespace CustomExtensions.Interfaces
{
    /// <summary>
    /// Contains methods to write lines of text
    /// </summary>
    public interface ILineWriter
    {
        void WriteLine();
        void WriteLine(string value);
    }
}