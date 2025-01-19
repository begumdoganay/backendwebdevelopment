using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore_Web_Application.Core.Constants.Messages
{
    public static class ErrorMessages
    {
        public const string NotFound = "Kayıt bulunamadı";
        public const string InvalidCredentials = "Geçersiz kullanıcı adı veya şifre";
        public const string UnauthorizedAccess = "Bu işlem için yetkiniz bulunmamaktadır";
        public const string InvalidToken = "Geçersiz veya süresi dolmuş token";
        public const string InsufficientStock = "Yetersiz stok";
        public const string DuplicateISBN = "Bu ISBN koduna sahip kitap zaten mevcut";
    }
}
