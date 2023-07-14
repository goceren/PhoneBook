using PhoneBook.Data.Business.Abstract;
using PhoneBook.Data.Business.Concrete;
using PhoneBook.Data.Core.DataAccess;
using PhoneBook.Data.Core.DataAccess.EntityFramework;
using PhoneBook.Data.DataAccess.Abstract;
using PhoneBook.Data.DataAccess.Concrete;

namespace PhoneBook.Data.Api.Infrastructures
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {

            #region Business

            services.AddTransient<IBookService, BookManager>();
            services.AddTransient<IBookContactService, BookContactManager>();
            #endregion

            #region DataAccess

            services.AddTransient<IBookDal, EfBookDal>();
            services.AddTransient<IBookContactDal, EfBookContactDal>();

            #endregion

            return services;
        }
    }
}
