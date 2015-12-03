namespace Swimmy.Web
{
    using System.Data.Entity;
    using System.Reflection;
    using System.Web.Http;

    using Autofac;
    using Autofac.Integration.WebApi;

    using Swimmy.Data;
    using Swimmy.Data.Infrastructure;
    using Swimmy.Data.Infrastructure.Contracts;
    using Swimmy.Services;
    using Swimmy.Services.Contracts;

    public class AutofacWebapiConfig
    {
        public static IContainer Container;

        public static void Initialize(
            HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }

        public static void Initialize(
            HttpConfiguration config,
            IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(
            ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            containerBuilder.RegisterType<SwimmingResultsContext>()
                            .As<DbContext>()
                            .InstancePerRequest();

            containerBuilder.RegisterType<DbFactory>()
                            .As<IDbFactory>()
                            .InstancePerRequest();

            containerBuilder.RegisterType<UnitOfWork>()
                            .As<IUnitOfWork>()
                            .InstancePerRequest();

            containerBuilder.RegisterGeneric(typeof(EntityBaseRepository<>))
                            .As(typeof(IEntityBaseRepository<>))
                            .InstancePerRequest();

            containerBuilder.RegisterType<EncryptionService>()
                            .As<IEncryptionService>()
                            .InstancePerRequest();

            containerBuilder.RegisterType<MembershipService>()
                            .As<IMembershipService>()
                            .InstancePerRequest();

            Container = containerBuilder.Build();

            return Container;
        }
    }
}