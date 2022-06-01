using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Constants
{
    public class Messages
    {
        public static string SuccessAddOperation  => "Ekleme işlemi başarıyla sonuçlandı."; 
        public static string ErrorAddOperation => "Ekleme işlemi hatayla sonuçlandı"; 

        public static string SuccessDeleteOperation => "Silme işlemi başarıyla sonuçlandı."; 
        public static string ErrorDeleteOperation  => "Silme işlemi başarıyla sonuçlandı."; 

        public static string SuccessUpdateOperation  => "Güncelleme işlemi başarıyla sonuçlandı."; 
        public static string ErrorUpdateOperation  => "Güncelleme işlemi başarıyla sonuçlandı."; 

        public static string SuccessLoginOperation  => "Başarıyla giriş yaptınız"; 
        public static string ErrorLoginOperation  => "Giriş yapmaya çalışırken bazı hatalar ile karşılaşıldı."; 

        public static string SuccessRegisterOperation  => "Başarıyla kayıt oldunuz"; 
        public static string ErrorRegisterOperation  => "Kayıt olmaya çalışırken bazı hatalar ile karşılaşıldı"; 

        public static string UserFound  => "Kullanıcı başarıyla bulundu"; 
        public static string UserNotFound  => "Kullanıcı bulunamadı"; 
        public static string CreatedAccessToken  => "Token Başarıyla oluşturuldu"; 

        public static string InternelServerError  => "Internel Server Error!"; 
        public static string AuthorizationDenied  => "Yetkiniz yok.";

        public static string ErrorPasswordOperation => "Hatalı parola!";
    }
}
