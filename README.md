# 🚀 ASP.NET Core MVC ile Admin Panelli Travel Projesi

Bu proje, **ASP.NET Core MVC** ve **Entity Framework Core Code First** kullanılarak geliştirilmiş, dinamik içerik yönetimi sunan bir **seyahat (travel) sitesi** projesidir. Ziyaretçilere özel turlar, geziler ve rehberler sunulmakta; admin paneli ile bu içerikler kolayca yönetilebilmektedir.

## 🔍 Proje Özeti

- 🌍 Dinamik tur ve gezi içerikleri
- 📧 Abonelik sistemi ve bildirim altyapısı
- 🧑‍💼 Gelişmiş admin paneli
- 🔐 Giriş ve yetkilendirme sistemleri
- 🎨 Modern tasarım ve bildirimler

## ☄️ Kazanımlar ve Teknik Özellikler

### 🌟 ASP.NET Core MVC Altyapısı
- Responsive tasarım prensipleriyle geliştirilen, modern ve ölçeklenebilir bir web uygulaması.
- ViewComponent kullanımı ile modüler ve tekrar kullanılabilir yapılar.

### 🌟 Entity Framework Core ile Veritabanı Yönetimi (SQL Server - Code First)
- `TravelContext` sınıfı aracılığıyla veritabanı işlemleri gerçekleştirilmiştir.
- Turlar, geziler, rehberler, kullanıcılar ve abonelikler gibi yapılar için tablolar oluşturulmuş ve ilişkiler tanımlanmıştır.
- Admin girişleri, profil verileri ve içerik yönetimi Entity Framework Core üzerinden kontrol edilmektedir.

### 🌟 Authentication & Authorization
- Cookie tabanlı kimlik doğrulama sistemi entegre edilmiştir.
- `[Authorize]` attribute'u ile sadece yetkili admin kullanıcıların erişim sağlayabileceği alanlar sınırlandırılmıştır.

### 🌟 Session & Cookie Yönetimi
- Admin kullanıcı oturumları ve tercihleri session & cookie teknolojileri ile korunmaktadır.

### 🌟 FluentValidation ile Gelişmiş Form Doğrulama
- Tüm kullanıcı formları, FluentValidation kuralları ile doğrulanmıştır.
- Hatalı girişlerin önüne geçilerek veri bütünlüğü sağlanmıştır.

### 🌟 SweetAlert2 ile Modern Bildirim Sistemi
- Abonelik işlemleri ve form gönderimleri sonrasında kullanıcıya başarılı/başarısız işlem bildirimi gösteren şık alert yapıları entegre edilmiştir.

### 🌟 Dinamik Abonelik Sistemi
- Ziyaretçilerin e-posta adresleriyle abone olabildiği bir sistem geliştirilmiştir.
- Gelen abonelik istekleri admin paneline bildirim olarak düşmekte ve listelenebilmektedir.

### 🌟 Kullanıcı Dostu Admin Paneli
- Admin panelinde son abonelik bildirimleri, içerik yönetimi (turlar, geziler, rehberler), kullanıcı bilgileri gibi tüm veriler kolayca yönetilebilir.
- Admin paneli modern bir arayüz ile hazırlanmış olup kullanıcı deneyimi öncelikli tutulmuştur.

### 🌟 Dosya Yükleme (Resim Upload) İşlemleri
- Turlar, geziler ve rehberlere özel görseller yüklenebilmektedir.
- Yüklenen görseller `wwwroot/images` klasörüne kaydedilmekte ve yol bilgisi veritabanına kaydedilmektedir.

### 🌟 Şifre Güncelleme Özelliği
- Admin kullanıcı mevcut şifresini doğrulayarak yeni bir şifre belirleyebilmektedir.
- Şifre değiştirme işlemlerinde geçerlilik ve eşleşme kontrolleri yapılmaktadır.

### 🌟 Özel 404 Hata Sayfası
- Hem kullanıcı hem admin paneli için özelleştirilmiş 404 hata sayfası entegre edilmiştir.

---

## 🖼️ Ekran Görüntüleri





![]([screenshots/homepage.png](https://github.com/eniscode/AcunMedyaTravelProject/blob/master/AcunMedyaTravelProject/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-05-10%20180323.png))


---

## ⚙️ Kurulum Adımları

Aşağıdaki adımları takip ederek projeyi kendi bilgisayarınızda çalıştırabilirsiniz:

1. **Projeyi klonlayın**
   ```bash
   git clone https://github.com/kullaniciadi/travel-project.git
   cd travel-project
