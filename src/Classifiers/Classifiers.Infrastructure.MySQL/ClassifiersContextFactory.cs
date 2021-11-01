using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using CDPN.Classifiers.Infrastructure.Data;

namespace CDPN.Classifiers.Infrastructure.MySql
{
    public class ClassifiersContextFactory : IDesignTimeDbContextFactory<ClassifiersContext>
    {
        public ClassifiersContext CreateDbContext(string[] args)
        {
            var migrationsAssembly = typeof(ClassifiersContextFactory).GetTypeInfo().Assembly.GetName().Name;
            var connectionString = @"Server=127.0.0.1;Port=3306;Database=CdpnClassifiers;Uid=myUsername;Pwd=myPassword;";
            var builder = new DbContextOptionsBuilder<ClassifiersContext>();
            builder.UseMySql(connectionString, 
                new MySqlServerVersion(new Version(8, 0, 23)), x =>
                {
                    x.MigrationsAssembly(migrationsAssembly);
                    x.MigrationsHistoryTable(DbContextConsts.MigrationsHistoryTableName);
                });
            return new ClassifiersContext(builder.Options);
        }
    }
}
