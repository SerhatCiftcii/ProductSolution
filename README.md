# Ürün Yönetimi API

Bu proje, basit bir katmanlı mimariye (monolith içinde katmanlı yapı)
sahip, ürün yönetimi için tasarlanmış bir RESTful API'dır. Proje, temel
CRUD (Oluşturma, Okuma, Güncelleme, Silme) operasyonlarını
desteklemektedir.

## Proje Mimarisi

Proje, sorumlulukları ayırmak için üç ana katmana ayrılmıştır:

-   **Product.API**: API uç noktalarını (Controllers) ve uygulamanın
    başlangıç ayarlarını (Program.cs) içeren giriş noktasıdır.
-   **Product.Services**: İş mantığının bulunduğu katmandır. Veri
    transfer objelerini (DTO) ve IProductRepository'den gelen verilerle
    işlemleri yönetir.
-   **Product.Repositories**: Veritabanı işlemleri için kullanılan veri
    erişim katmanıdır. IProductRepository arayüzünü uygular.

## Kurulum ve Çalıştırma

### Ön Gereksinimler

-   .NET 8.0 SDK
-  MS SQL Server 
-   Visual Studio veya Visual Studio Code
-   
**No**: Adımları hangi kullancıysanız onagöre yapın
### Adımlar

#### Projeyi Klonlama:

Visual Studio'yu açın. "Git" menüsünden "Clone Repository" seçeneğine
tıklayın.\
Açılan pencerede, Repository location bölümüne aşağıdaki adresi girin:

    https://github.com/SerhatCiftcii/ProductSolution.git

Projeyi klonlayıp açın.

Visual Studio Code / Terminal kullanıcıları için:
Terminali veya Visual Studio Code'un entegre terminalini açın. Projeyi klonlamak istediğiniz dizine gidin ve aşağıdaki komutu çalıştırın:

git clone https://github.com/SerhatCiftcii/ProductSolution.git


#### Veritabanı Bağlantı Ayarlarını Yapılandırma:

Product.API projesindeki `appsettings.json` dosyasını açın.\
`MsSqlConnection` anahtarının değerini, kendi SQL Server sunucu adınıza
ve veritabanı adınıza göre güncelleyin. Örneğin:

``` json
{
  "ConnectionStrings": {
    "MsSqlConnection": "Server=SERHAT\\SQLEXPRESS; Database=ProductDB; Trusted_Connection=True; TrustServerCertificate=True;"
  }
}
```

Buradaki `SERHAT\\SQLEXPRESS` kısmını kendi sunucu adınızla  ***Aynı İsimde Database varsa ProductDB isminde ozaman Database isminide değiştirin(Bu Opsiyenel aynı isimden eğer hata verirse bilgilendirmesi)***
değiştirmelisiniz.

#### Veritabanı Oluşturma (Migration):

**Visual Studio kullanıcıları için:** 1. Visual Studio'da
`Tools > NuGet Package Manager > Package Manager Console`'u açın. 2.
Konsolun üst kısmındaki "Default project" açılır menüsünden
`Product.Repositories` projesini seçin. 3. Aşağıdaki komutları
çalıştırın:

    Add-Migration newMig
    Update-Database

**Visual Studio Code / Terminal kullanıcıları için:** 1. Terminali açın
ve projenin ana dizinine (`ProductSolution`) gidin. 2. Aşağıdaki
komutları çalıştırın:

    dotnet tool install --global dotnet-ef
    dotnet ef migrations add newMig --project Product.Repositories --startup-project Product.API
    dotnet ef database update --project Product.Repositories --startup-project Product.API

#### Projeyi Çalıştırma:

**Visual Studio kullanıcıları için:** - Projeyi Visual Studio'da `F5`
tuşuna basarak veya `Product.API` projesine sağ tıklayıp *Set as Startup
Project* seçeneğini seçtikten sonra `Ctrl + F5` tuş kombinasyonuyla
çalıştırabilirsiniz.

**Visual Studio Code / Terminal kullanıcıları için:** - Terminali açın
ve `Product.API` projesinin dizinine gidin. - Aşağıdaki komutu
çalıştırın:

    dotnet run

API'ye `https://localhost:[port]` adresinden erişebilirsiniz. Varsayılan
olarak Swagger UI otomatik olarak açılacaktır.

## API Uç Noktaları

  ------------------------------------------------------------------------
  HTTP Metodu    Uç Nokta                 Açıklama
  -------------- ------------------------ --------------------------------
  GET            /api/products            Tüm ürünleri listeler.

  GET            /api/products/{id}       Belirli bir ürünün detayını
                                          getirir.

  POST           /api/products            Yeni bir ürün ekler.

  PUT            /api/products            Mevcut bir ürünü günceller.

  DELETE         /api/products/{id}       Belirli bir ürünü siler.
  ------------------------------------------------------------------------


