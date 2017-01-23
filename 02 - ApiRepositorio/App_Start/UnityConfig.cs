using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;
using _02___ApiRepositorio.Models.EF;
using _02___ApiRepositorio.Models.Views;
using _02___ApiRepositorio.Repositorios;
using _02___ApiRepositorio.Repositorios.Base;

namespace _02___ApiRepositorio
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);

            container.RegisterType<clasetajamarEntities>();

            container.RegisterType<Repositorio<DireccionViewModel, Direccion>>();
            container.RegisterType<RepositorioPersona>();
        }
    }
}