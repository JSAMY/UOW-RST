using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Microsoft.Practices.Unity.Mvc;
using Restaurant.Common;
using Restaurant.DAL;
using Restaurant.DatabaseContext;
using Restaurant.Interface;
using Restaurant.Interface.Repository;
using System.Web.Mvc;

namespace Restaurant.Web
{
    public static class BootStrap
    {
        public static void BuildContainer()
        {
            var container = BuildUnityContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {

            IUnityContainer uContainer = new UnityContainer();

            uContainer.RegisterType(typeof(IRepository<>), typeof(Repository<>));
            uContainer.RegisterType(typeof(IUnitOfWork), typeof(UnitOfWork));
            uContainer.RegisterType(typeof(IApplicationDbContext), typeof(ApplicationDbContext));
            uContainer.RegisterType(typeof(IEmail), typeof(EmailService));
            return uContainer;

        }
    }
}