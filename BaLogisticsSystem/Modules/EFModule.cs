using System.Data.Entity;
using Autofac;
using BaLogisticsSystem.DAL;
using BaLogisticsSystem.Repository.Common;

namespace BaLogisticsSystem.Modules
{
    public class EfModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new RepositoryModule());

            builder.RegisterType(typeof(BaLogisticsSystemContext)).As(typeof(DbContext)).InstancePerLifetimeScope();
            builder.RegisterType(typeof(UnitOfWork)).As(typeof(IUnitOfWork)).InstancePerRequest();
        }
    }
}