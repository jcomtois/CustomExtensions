namespace UnitTests.ForStringsTests
{
    public partial class StringTests
    {
        public class EncryptionTestBase
        {
            protected const string EmptyKey = "";
            protected const string NullKey = null;
            protected const string ShortKey = "short";
            protected const string ValidLengthKey = "0123456789ABCDEF";
        }
    }
}