**Proje Kurulumu**

- "src/AppGateways/Data" konumunda bulunan "PhoneBook.Data.Api" projesini "set a startup project" olarak işaretledikten sonra appsettings.json dosyasına PostgreSQL ConnectionString yazılır. 
- "PhoneBook.Data.DataAccess" projesini Package Manager Console'unda "update-database" komutuyla PostgreSQL veritabanını oluşturulur.
- "src/AppGateways/Report" konumunda bulunan "PhoneBook.Report.Api" projesini "set a startup project" olarak işaretledikten sonra appsettings.json dosyasına PostgreSQL ConnectionString yazılır. 
- "PhoneBook.Report.DataAccess" projesini Package Manager Console'unda "update-database" komutuyla PostgreSQL veritabanını oluşturulur.

RabbitMQ Configuration ise yine "EventBus.RabbitMQ" projesinin appsettings.json dosyayında bulunmaktadır.

Ardından Solution üzerine sağ tıklayarak startup project olarak;
- PhoneBook.Data.Api
- PhoneBook.Report.Api
- EventBus.RabbitMQ
- PhoneBook.Web.WebApp
- ReportService

projeleri seçilir ve proje başlatılır.

TEKNOLOJILER

- .Net 6 API with Swagger 
- .Net 6 MVC 
- RabbitMQ 
- EntityFramework Core 
- PostgreSQL
- BackgroundService
  
