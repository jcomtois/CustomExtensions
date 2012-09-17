namespace CustomExtensions.Validation
{
    // http://blog.getpaint.net/2008/12/06/a-fluent-approach-to-c-parameter-validation/

    /// <summary>
    /// Static class solely for the purpose of gaining access to Validation Extension Methods
    /// </summary>
    public static class Validate
    {
        /// <summary>
        /// Provides a null reference of <see cref="Validation"/> to access Extension Methods
        /// </summary>
        /// <returns>A null <see cref="Validation"/> reference.</returns>
        public static Validation Begin()
        {
            return null;
        }
    }
}