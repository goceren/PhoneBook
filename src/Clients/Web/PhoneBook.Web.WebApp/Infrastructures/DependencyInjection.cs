using PhoneBook.Web.Business.Abstract;
using PhoneBook.Web.Business.Concrete;

namespace PhoneBook.Web.Infrastructure
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {

            #region Business

            services.AddTransient<IReportService, ReportManager>();
            services.AddTransient<IBookService, BookManager>();
            services.AddTransient<IBookContactService, BookContactManager>();

            #endregion

            return services;
        }
    }
}
