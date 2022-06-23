1-) Common katman�mda, kriptolama, dekriptolama, Enumlar�m, Token, Current User'� �a��raca��m class gibi genel olan, her yerde kullanaca��m classlar�m bulunmaktad�r.Bu projemi her katmana referans verip bu genel makasatl� classlar�m�n kullan�m�n� sa�lad�m.
Ayr�ca Common katman�nda DTOs'da API katman�nda kullanaca��m classlar�m� olu�turuyorum. bu classlar�m Proje.Model=>Entities i�indeki Database Class'lar�m ile ayn� fakat AP� de kullanaca��m �ekilde planlad�m.
2-) Library=>ProjeCore i�erisinde, Interfacelerimi ve Base classlar�m� konumland�rd�m.
3_) Model katman�m i�erisinde DataContex'im, Entities i�erisinde ; Database'ye Entity Framework ile kuraca��m tablolar� olu�turaca��m classlar�m� olu�turdum. Maps i�erisinde Entities'de olu�turdu�um class'lar�m� fluent mapping ile �ekillendirdim.�rnek olu�turmas� a��s�ndan SeedData ile PostgreSQL'de olu�acak classlar�m� doldurdum.
4-)Library=>Proje.Service katman�mda as�l Repository'lerimi olu�turdum.
5-) Proje.API projem i�erisinde API controlar�m� olu�turdum. bu controllar vas�tas�yla databaseden her t�rl� veri �ekme g�ncelleme silme i�lemleri yap�l�p swagger ile denendi.
6-) UI katman�mda Refit ile AP� de olu�turdu�um Controller'lar� d�n��t�r�p yeni kontrollarlar�m� olu�turdum ve frontend i�lemlerimi tamamlad�m. Projem JWT token ile Authorize i�lemini yap�yor. Ayr�ca UI katman�mda UI daki controllar i�in yeni classlar olu�turdum. Admin katmn�n� Areaya kurup User daki Title ba�l���na g�re kullan�c� yada admin y�z�ne y�nlendiriyorum. Sepet i�lemini(CartsController i�erisinde) Cookie ile y�nettim.Sepetimi de UI da kriptolad�m.

Projeyi aya�a kald�r�rken ProjeApi katman�n� startup olarak se�ip update-database ile databasemi kurup, sonra UI2� �al��t�r�yorum.


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

