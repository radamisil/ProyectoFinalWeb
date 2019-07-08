using AdondeVamos.DAL;
using AdondeVamos.Facade;
using AdondeVamos.Mapping;
using Autofac.Integration.Mvc;
using AdondeVamos.Model.UnitOfWork;
using Autofac;
using Autofac.Core;
using Autofac.Integration.WebApi;
using AutoMapper;
using log4net;
using System;
using System.Linq;
using System.Reflection;
using AdondeVamos.Repository;
using AdondeVamos.Services;
using AdondeVamos.Services.Interfaces;
using AdondeVamos.Model.GenericClass;

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
            builder.RegisterControllers(assemblyInfo);

            //inject Log4Net dependency
            builder.RegisterModule(new LogInjectionModule());

            //register DbContext, UnitOfWork and Repositories
            builder.RegisterType<aDondeVamosContext>()
                .As<IDbContext>()
                .InstancePerRequest();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            /// <summary>
            /// register all available services
            /// </summary>
            builder.RegisterType<ApiService>().As<IApiService>();

            /// <summary>
            /// register all available facades
            /// </summary>
            builder.RegisterType<UsuarioFacade>().As<IUsuarioFacade>();
            //builder.RegisterType<APIResponse>();

            //register all project services 
            builder.RegisterType<BaseService>();
            builder.RegisterType<PromocionService>();
            builder.RegisterType<UsuarioService>();            

            var autoMapperConfig = new AutoMapperConfig();

            Type[] typesApi = Assembly.GetExecutingAssembly().GetExportedTypes();
            //Type[] typesModel = Assembly.Load("AdondeVamos.Model").GetExportedTypes();
            //Type[] typesServices = Assembly.Load("AdondeVamos.Services").GetExportedTypes();

            var types = new Type[typesApi.Length];
            typesApi.CopyTo(types, 0);
            //typesModel.CopyTo(types, typesApi.Length);
            //typesServices.CopyTo(types, typesApi.Length + typesModel.Length);


            autoMapperConfig.Execute(types);
            var mapper = autoMapperConfig.Configuration.CreateMapper();
            builder.RegisterInstance<IMapper>(mapper);

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