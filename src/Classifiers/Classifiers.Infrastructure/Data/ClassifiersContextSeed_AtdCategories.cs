using CDPN.Classifiers.Entities;

namespace CDPN.Classifiers.Infrastructure.Data
{
    public partial class ClassifiersContextSeed
    {
        // Кодифікатор адміністративно-територіальних одиниць та територій територіальних громад (КАТОТТГ)
        // http://www.ukrstat.gov.ua/klasf/nac_kls/tab_kato.htm
        private static List<AtdCategory> GetPreconfiguredAtdCategories()
        {
            return new List<AtdCategory>()
            {
                new AtdCategory { Id = "S", Name = "Країна" },
                new AtdCategory { Id = "O", Name = "Область/Автономія" },
                new AtdCategory { Id = "K", Name = "Місто, що має спеціальний статус" },
                new AtdCategory { Id = "P", Name = "Район в області/автономії" },
                new AtdCategory { Id = "H", Name = "Територія територіальной громади" },
                new AtdCategory { Id = "M", Name = "Місто" },
                new AtdCategory { Id = "T", Name = "Селище міського типу" },
                new AtdCategory { Id = "C", Name = "Село" },
                new AtdCategory { Id = "X", Name = "Селище" },
                new AtdCategory { Id = "B", Name = "Район у місті" },
            };
        }
    }
}
