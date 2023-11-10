using App.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Constants
{
  public static class Messages
  {
    public static string ProductAdded = "Urun eklendi";
    public static string ProductNameInvalid = "Urun ismi gecersiz";
    public static string MaintenanceTime = "Sistem bakimda";
    public static string ProductsListed = "Urunler listelendi";
    public static string ProductCountOfCategoryError = "Kategoride en fazla 10 urun olabilir";
    public static string ProductNameAlreadyExists = "Bu isimde bir urun zaten var";
    public static string CategoryLimitExceded = "Kategori limit asildigi icin yeni urun eklenemiyor";
    public static string AuthorizationDenied = "Giris izni verilmedi.";
    public static string UserRegistered = "Kullanici olusturuldu";
    public static string UserNotFound = "Kullanici bulunamadi";
    public static string PasswordError = "Sifre hatali";
    public static string SuccessfulLogin = "Kullanici girisi gerceklestirildi";
    public static string UserAlreadyExists = "Bu kullanici zaten mevcut";
    public static string AccessTokenCreated = "Giris tokeni yaratildi";
  }
}
