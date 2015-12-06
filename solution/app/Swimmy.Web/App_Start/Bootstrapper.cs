namespace Swimmy.Web
{
    using System.Web.Http;

    public class Bootstrapper
    {
        public static void Run()
        {
            // Configure autofac
            AutofacWebapiConfig.Initialize(GlobalConfiguration.Configuration);

            // Configure autoMapper

        }
    }
}