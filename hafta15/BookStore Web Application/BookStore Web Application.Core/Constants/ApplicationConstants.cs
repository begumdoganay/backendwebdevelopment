using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore_Web_Application.Core.Constants
{
    public static class ApplicationConstants
    {
        public const int MinPasswordLength = 6;
        public const int MaxPasswordLength = 100;
        public const int MaxTitleLength = 200;
        public const int MaxNameLength = 100;
        public const int MaxEmailLength = 100;
        public const string DefaultLanguage = "tr";
        public const int DefaultPageSize = 10;

        public static class CacheKeys
        {
            public const string BooksList = "books_list";
            public const string AuthorsList = "authors_list";
            public const string CategoriesList = "categories_list";
        }
    }
}
