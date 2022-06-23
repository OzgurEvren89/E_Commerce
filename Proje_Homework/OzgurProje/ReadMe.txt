1-) Common katmanýmda, kriptolama, dekriptolama, Enumlarým, Token, Current User'ý çaðýracaðým class gibi genel olan, her yerde kullanacaðým classlarým bulunmaktadýr.Bu projemi her katmana referans verip bu genel makasatlý classlarýmýn kullanýmýný saðladým.
Ayrýca Common katmanýnda DTOs'da API katmanýnda kullanacaðým classlarýmý oluþturuyorum. bu classlarým Proje.Model=>Entities içindeki Database Class'larým ile ayný fakat APÝ de kullanacaðým þekilde planladým.
2-) Library=>ProjeCore içerisinde, Interfacelerimi ve Base classlarýmý konumlandýrdým.
3_) Model katmaným içerisinde DataContex'im, Entities içerisinde ; Database'ye Entity Framework ile kuracaðým tablolarý oluþturacaðým classlarýmý oluþturdum. Maps içerisinde Entities'de oluþturduðum class'larýmý fluent mapping ile þekillendirdim.Örnek oluþturmasý açýsýndan SeedData ile PostgreSQL'de oluþacak classlarýmý doldurdum.
4-)Library=>Proje.Service katmanýmda asýl Repository'lerimi oluþturdum.
5-) Proje.API projem içerisinde API controlarýmý oluþturdum. bu controllar vasýtasýyla databaseden her türlü veri çekme güncelleme silme iþlemleri yapýlýp swagger ile denendi.
6-) UI katmanýmda Refit ile APÝ de oluþturduðum Controller'larý dönüþtürüp yeni kontrollarlarýmý oluþturdum ve frontend iþlemlerimi tamamladým. Projem JWT token ile Authorize iþlemini yapýyor. Ayrýca UI katmanýmda UI daki controllar için yeni classlar oluþturdum. Admin katmnýný Areaya kurup User daki Title baþlýðýna göre kullanýcý yada admin yüzüne yönlendiriyorum. Sepet iþlemini(CartsController içerisinde) Cookie ile yönettim.Sepetimi de UI da kriptoladým.

Projeyi ayaða kaldýrýrken ProjeApi katmanýný startup olarak seçip update-database ile databasemi kurup, sonra UI2ý çalýþtýrýyorum.


Common 
--------------------------------
AutoMapper.Extensions.Microsoft.DependencyInjection 7.0.0

Core => References(Common)
--------------------------------
Microsoft.EntityFrameworkCore 3.1.22

Model => References(Common,Core)
--------------------------------
Microsoft.EntityFrameworkCore 3.1.22
Microsoft.EntityFrameworkCore.Relational 3.1.22
Npgsql.EntityFrameworkCore.PostgreSQL 3.1.22
Microsoft.AspNetCore.Http.Abstractions 2.2.0
Microsoft.EntityFrameworkCore.Design 3.1.22
Microsoft.AspNetCore.Http 2.2.2
Microsoft.Extensions.Configuration.Json 3.1.22
Microsoft.Extensions.Configuration.EnvironmentVariables 3.1.22

Service => References(Core,Model)
--------------------------------

API => References(Common,Model,Service)
--------------------------------
Microsoft.EntityFrameworkCore 3.1.22
Microsoft.EntityFrameworkCore.Tools 3.1.22
Npgsql.EntityFrameworkCore.PostgreSQL 3.1.18
AutoMapper.Extensions.Microsoft.DependencyInjection 7.0.0
Microsoft.AspNetCore.Authentication.JwtBearer 3.1.22
Swashbuckle.AspNetCore.Swagger 6.2.3
Swashbuckle.AspNetCore.SwaggerGen 6.2.3
Swashbuckle.AspNetCore.SwaggerUI 6.2.3

WEB.UI => References(Common)
--------------------------------
AutoMapper.Extensions.Microsoft.DependencyInjection 7.0.0
Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation 3.1.22
Microsoft.Extensions.Http.Polly 3.1.22
Refit.HttpClientFactory 6.3.2
Microsoft.VisualStudio.Web.CodeGeneration.Design 3.1.5

