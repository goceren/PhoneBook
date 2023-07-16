using PhoneBook.Data.Business.Concrete;
using PhoneBook.Report.Business.Abstract;
using PhoneBook.Report.DataAccess.Abstract;
using PhoneBook.Report.DataAccess.Concrete;

namespace PhoneBook.Report.Api.Infrastructures
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {

            #region Business

            services.AddTransient<IReportService, ReportManager>();
            #endregion

            #region DataAccess

            services.AddTransient<IReportRepository, ReportRepository>();

            #endregion

            services.AddTransient<IUnitOfWorkReport, UnitOfWorkReport>();



            return services;
        }
    }
}
