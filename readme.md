
Proje Kurulumu

* "src/AppGateways/Data" konumunda bulunan "PhoneBook.Data.Api" projesini "set a startup project" olarak i�aretledikten sonra appsettings.json dosyas�na PostgreSQL ConnectionString yaz�l�r.
"PhoneBook.Data.DataAccess" projesini Package Manager Console'unda "update-database" komutuyla PostgreSQL veritaban�n� olu�turulur.

* "src/AppGateways/Report" konumunda bulunan "PhoneBook.Report.Api" projesini "set a startup project" olarak i�aretledikten sonra appsettings.json dosyas�na PostgreSQL ConnectionString yaz�l�r.
"PhoneBook.Report.DataAccess" projesini Package Manager Console'unda "update-database" komutuyla PostgreSQL veritaban�n� olu�turulur.

* RabbitMQ Configuration ise yine "EventBus.RabbitMQ" projesinin appsettings.json dosyay�nda bulunmaktad�r.

* Ard�ndan Solution �zerine sa� t�klayarak startup project olarak;
	** PhoneBook.Data.Api
	** PhoneBook.Report.Api
	** EventBus.RabbitMQ
	** PhoneBook.Web.WebApp
	** ReportService

projeleri se�ilir ve proje ba�lat�l�r.



TEKNOLOJILER

.Net 6 API with Swagger
.Net 6 MVC
RabbitMQ
EntityFramework Core
PostgreSQL




