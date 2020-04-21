[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(LCesarAdvogados.MVC.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(LCesarAdvogados.MVC.App_Start.NinjectWebCommon), "Stop")]

namespace LCesarAdvogados.MVC.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using LCesarAdvogados.Aplicacao.Interface;
    using LCesarAdvogados.Aplicacao;
    using LCesarAdvogados.Dominio.Servicos;
    using LCesarAdvogados.Dominio.Interfaces.Servicos;
    using LCesarAdvogados.Dominio.Interfaces;
    using LCesarAdvogados.Infra.Repositorios;
    using LCesarAdvogados.Dominio.Interfaces.Repositorios;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind(typeof(IAppServicoBase<>)).To(typeof(AppServicoBase<>));
            kernel.Bind<IUsuarioAppServico>().To<UsuarioAppServico>();
            kernel.Bind<IPostAppServicos>().To<PostAppServico>();

            kernel.Bind(typeof(IServicoBase<>)).To(typeof(ServicoBase<>));
            kernel.Bind<IUsuarioServico>().To<UsuarioServico>();
            kernel.Bind<IPostServico>().To<PostServico>();

            kernel.Bind(typeof(IRepositorioBase<>)).To(typeof(RepositorioBase<>));
            kernel.Bind<IUsuarioRepositorio>().To<UsuarioRepositorio>();
            kernel.Bind<IPostRepositorio>().To<PostRepositorio>();
        }        
    }
}
