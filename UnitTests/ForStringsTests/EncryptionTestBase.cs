namespace UnitTests.ForStringsTests
{
    public partial class StringTests
    {
        public class EncryptionTestBase
        {
            protected const string EmptyKey = "";
            protected const string EmptyTestString = "";
            protected const string NullKey = null;
            protected const string NullTestString = null;
            protected const string ShortKey = "short";
            protected const string ValidLengthKey = "0123456789ABCDEF";
            protected const string ValidTestString = "The quick brown fox jumped over the lazy dog.  1234567890 !@#$%^&*()_+~~~~~~\\n\n\n";
        }
    }
}