namespace BookStore.Shared.Constants
{
    public static class ApplicationConstants
    {
        public static class ErrorMessages
        {
            public const string NotFound = "Resource not found";
            public const string InvalidInput = "Invalid input provided";
            public const string ValidationError = "Validation error occurred";
        }

        public static class CacheKeys
        {
            public const string BookList = "BookList";
            public const string AuthorList = "AuthorList";
        }
    }
}