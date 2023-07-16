
Proje Kurulumu

* "src/AppGateways/Data" konumunda bulunan "PhoneBook.Data.Api" projesini "set a startup project" olarak iþaretledikten sonra appsettings.json dosyasýna PostgreSQL ConnectionString yazýlýr.
"PhoneBook.Data.DataAccess" projesini Package Manager Console'unda "update-database" komutuyla PostgreSQL veritabanýný oluþturulur.

* "src/AppGateways/Report" konumunda bulunan "PhoneBook.Report.Api" projesini "set a startup project" olarak iþaretledikten sonra appsettings.json dosyasýna PostgreSQL ConnectionString yazýlýr.
"PhoneBook.Report.DataAccess" projesini Package Manager Console'unda "update-database" komutuyla PostgreSQL veritabanýný oluþturulur.

* RabbitMQ Configuration ise yine "EventBus.RabbitMQ" projesinin appsettings.json dosyayýnda bulunmaktadýr.

* Ardýndan Solution üzerine sað týklayarak startup project olarak;
	** PhoneBook.Data.Api
	** PhoneBook.Report.Api
	** EventBus.RabbitMQ
	** PhoneBook.Web.WebApp
	** ReportService

projeleri seçilir ve proje baþlatýlýr.



TEKNOLOJILER

.Net 6 API with Swagger
.Net 6 MVC
RabbitMQ
EntityFramework Core
PostgreSQL




