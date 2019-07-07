using AdondeVamos.DAL;
using AdondeVamos.Facade;
using AdondeVamos.Mapping;
using AdondeVamos.Model.UnitOfWork;
using Autofac;
using Autofac.Core;
using Autofac.Integration.WebApi;
using AutoMapper;
using log4net;
using System;
using System.Linq;
using System.Reflection;

namespace AdondeVamois.Dependencies
{    
    public static class DependencyResolver
    {        
        public static IContainer Setup()
        {
            //setup autofac
            var builder = new ContainerBuilder();

            var assemblyInfo = Assembly.GetExecutingAssembly();

            //register all Api controllers
            builder.RegisterApiControllers(assemblyInfo);

            //register all controllers
            //builder.RegisterControllers(assemblyInfo);

            //inject Log4Net dependency
            //builder.RegisterModule(new LogInjectionModule());
                        

            //builder.RegisterType<MercadoLibreRepository>().As<IMercadoLibreRepository>();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            /// <summary>
            /// register all available facades
            /// </summary>
            builder.RegisterType<UsuarioFacade>().As<IUsuarioFacade>();
           // builder.RegisterType<UsuarioFacade>().As<IUsuarioFacade>();

            //var autoMapperConfig = new AutoMapperConfig();

            // var mapper = autoMapperConfig.Configuration.CreateMapper();
            ///builder.RegisterInstance<IMapper>(mapper);

            return builder.Build();
        }                 

        public class LogInjectionModule : Autofac.Module
        {
            protected override void AttachToComponentRegistration(IComponentRegistry registry, IComponentRegistration registration)
            {
                registration.Preparing += OnComponentPreparing;
            }

            static void OnComponentPreparing(object sender, PreparingEventArgs e)
            {
                var t = e.Component.Activator.LimitType;
                e.Parameters = e.Parameters.Union(new[]
                {
                    new ResolvedParameter((p, i) => p.ParameterType == typeof(ILog), (p, i) => LogManager.GetLogger(t))
                });
            }
        }
    }
}