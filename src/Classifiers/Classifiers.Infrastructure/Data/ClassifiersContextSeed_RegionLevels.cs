using CDPN.Classifiers.Entities;

namespace CDPN.Classifiers.Infrastructure.Data
{
    public partial class ClassifiersContextSeed
    {
        // Кодифікатор адміністративно-територіальних одиниць та територій територіальних громад (КАТОТТГ)
        // http://www.ukrstat.gov.ua/klasf/nac_kls/tab_kato.htm
        private static List<RegionLevel> GetPreconfiguredRegionLevels()
        {
            return new List<RegionLevel>()
            {
                new RegionLevel { Id = 0, Name = "Країна" },
                new RegionLevel { Id = 1, Name = "Область/автономія або місто, що має спеціальний статус" },
                new RegionLevel { Id = 2, Name = "Район області/автономії" },
                new RegionLevel { Id = 3, Name = "Територія територіальних громад" },
                new RegionLevel { Id = 4, Name = "Населенний пункт (місто, селище міського типу, село, селище)" },
                new RegionLevel { Id = 5, Name = "Район у місті" }
            };
        }
    }
}
