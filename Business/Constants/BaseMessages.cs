using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public class BaseMessages
    {
        public static string Added = "Eklendi";
        public static string Deleted = "Silindi";
        public static string GetAll = "Listelendi";
        public static string GetById = "Getirildi";
        public static string Updated = "Güncellendi";
        public static string SameName = "Aynı isim zaten var";
        public static string NotExist = "İsim veya Id Bulunamadı-Geçersiz";
        public static string AlreadyExist = "İsim veya Id zaten mevcut";
        public static string Blacklisted = "Kişi Blacklist te";
    }
}
