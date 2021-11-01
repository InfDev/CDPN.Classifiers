using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using CDPN.Classifiers.Infrastructure.Data;

namespace CDPN.Classifiers.Infrastructure.Sqlite
{
    public class ClassifiersContextFactory : IDesignTimeDbContextFactory<ClassifiersContext>
    {
        public ClassifiersContext CreateDbContext(string[] args)
        {
            var migrationsAssembly = typeof(ClassifiersContextFactory).GetTypeInfo().Assembly.GetName().Name;
            var connectionString = @"Server=127.0.0.1;Port=5432;Database=CdpnClassifiers;Integrated Security=true;";
            var builder = new DbContextOptionsBuilder<ClassifiersContext>();
            builder.UseNpgsql(connectionString, x =>
            {
                x.MigrationsAssembly(migrationsAssembly);
                x.MigrationsHistoryTable(DbContextConsts.MigrationsHistoryTableName);
            });
            return new ClassifiersContext(builder.Options);
        }
    }
}
