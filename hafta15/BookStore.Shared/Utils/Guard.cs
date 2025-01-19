namespace BookStore.Shared.Utils
{
    public static class Guard
    {
        public static void Against<TException>(bool condition, string message) where TException : Exception
        {
            if (condition)
            {
                var exception = (TException?)Activator.CreateInstance(typeof(TException), message);
                if (exception is null)
                {
                    throw new InvalidOperationException($"Could not create an instance of {typeof(TException)}.");
                }
                throw exception;
            }
        }

        public static void AgainstNull(object value, string parameterName)
        {
            if (value == null)
            {
                throw new ArgumentNullException(parameterName);
            }
        }

        public static void AgainstNullOrEmpty(string value, string parameterName)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Value cannot be null or empty.", parameterName);
            }
        }
    }
}