using CDPN.Classifiers.Entities;

namespace CDPN.Classifiers.Infrastructure.Data
{
    public partial class ClassifiersContextSeed
    {
        // Кодифікатор адміністративно-територіальних одиниць та територій територіальних громад (КАТОТТГ)
        // http://www.ukrstat.gov.ua/klasf/nac_kls/tab_kato.htm
        private static List<AdminTerritorialCategory> GetPreconfiguredAdminTerritorialCategorys()
        {
            return new List<AdminTerritorialCategory>()
            {
                new AdminTerritorialCategory { Id = "S", Name = "Країна" },
                new AdminTerritorialCategory { Id = "O", Name = "Область/Автономія" },
                new AdminTerritorialCategory { Id = "K", Name = "Місто, що має спеціальний статус" },
                new AdminTerritorialCategory { Id = "P", Name = "Район в області/автономії" },
                new AdminTerritorialCategory { Id = "H", Name = "Територія територіальной громади" },
                new AdminTerritorialCategory { Id = "M", Name = "Місто" },
                new AdminTerritorialCategory { Id = "T", Name = "Селище міського типу" },
                new AdminTerritorialCategory { Id = "C", Name = "Село" },
                new AdminTerritorialCategory { Id = "X", Name = "Селище" },
                new AdminTerritorialCategory { Id = "B", Name = "Район у місті" },
            };
        }
    }
}
