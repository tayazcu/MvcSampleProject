using Autofac;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlphaProject
{
    public static class IoCContainer
    {
        public static void Register(ContainerBuilder builder)
        {
            var profiles = from types in typeof(ProductProfile).Assembly.GetTypes()
                           where typeof(Profile).IsAssignableFrom(types)
                           select (Profile)Activator.CreateInstance(types);

            builder.Register(ctx => new MapperConfiguration(cfg =>
            {
                foreach (var profile in profiles)
                    cfg.AddProfile(profile);
            })).SingleInstance().AutoActivate().AsSelf();


            builder.Register(ctx => ctx.Resolve<MapperConfiguration>().CreateMapper()).As<IMapper>().InstancePerRequest();
        }
    }
}