using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDPN.Classifiers.Infrastructure
{
    public class DbContextConsts
    {
        public const string DbTablePrefix = "Std";
        public const string MigrationsHistoryTableName = $"__{DbTablePrefix}_EFMigrationsHistory";
    }
}
