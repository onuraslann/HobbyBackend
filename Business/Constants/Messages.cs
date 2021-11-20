using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {

        public static string BookAdded = "Kitap  eklendi";
        public static string BookDeleted = "Kitap  silindi";
        public static string CategoryAdded = "Category eklendi";
        public static string MovieAdded = "Film eklendi";

        public static string SerieAdded = "Dizi eklendi";
        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string UsersAdded = "Kayıt işlemi başarılı bir şekilde gerçekleştirildi";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Hatalı parola";
        public static string SuccessLogin = "Giriş işlemi başarılı";
        public static string UserAlreadyExists = "Kullanıcı mevcut başka bir kullanıcı ismi giriniz";
        public static string AccessTokenAdded = "Token başarılı bir şekilde oluşturuldu";
    }
}
