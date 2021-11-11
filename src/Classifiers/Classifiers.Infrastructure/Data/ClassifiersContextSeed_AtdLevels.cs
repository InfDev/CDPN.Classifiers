using CDPN.Classifiers.Entities;

namespace CDPN.Classifiers.Infrastructure.Data
{
    public partial class ClassifiersContextSeed
    {
        // Кодифікатор адміністративно-територіальних одиниць та територій територіальних громад (КАТОТТГ)
        // http://www.ukrstat.gov.ua/klasf/nac_kls/tab_kato.htm
        private static List<AtdLevel> GetPreconfiguredAtdLevels()
        {
            return new List<AtdLevel>()
            {
                new AtdLevel { Id = 0, Name = "Країна", InUnitIdStartIndex = 0, InUnitIdEndIndex = 1 },
                new AtdLevel { Id = 1, Name = "Область/автономія або місто, що має спеціальний статус", InUnitIdStartIndex = 2, InUnitIdEndIndex = 3 },
                new AtdLevel { Id = 2, Name = "Район області/автономії", InUnitIdStartIndex = 4, InUnitIdEndIndex = 6 },
                new AtdLevel { Id = 3, Name = "Територія територіальних громад", InUnitIdStartIndex = 7, InUnitIdEndIndex = 9 },
                new AtdLevel { Id = 4, Name = "Населенний пункт (місто, селище міського типу, село, селище)", InUnitIdStartIndex = 10, InUnitIdEndIndex = 11 },
                new AtdLevel { Id = 5, Name = "Район у місті", InUnitIdStartIndex = 12, InUnitIdEndIndex = 13 }
            };
        }
    }
}
