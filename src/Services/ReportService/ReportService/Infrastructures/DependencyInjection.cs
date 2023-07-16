
using ReportService.Business.Abstract;
using ReportService.Business.Concrete;

namespace ReportService.Infrastructure
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {

            #region Business

            services.AddTransient<IReportQueueService, ReportQueueManager>();

            #endregion

            return services;
        }
    }
}
