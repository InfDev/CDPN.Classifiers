using CDPN.Classifiers.Entities;

namespace CDPN.Classifiers.Infrastructure.Data
{
    public partial class ClassifiersContextSeed
    {
        // Кодифікатор адміністративно-територіальних одиниць та територій територіальних громад (КАТОТТГ)
        // http://www.ukrstat.gov.ua/klasf/nac_kls/tab_kato.htm
        private static List<AtdUnit> GetPreconfiguredAtdUnits()
        {
            return new List<AtdUnit>()
            {
                // Страны
                new AtdUnit { Id = "BY", ParentId = null, AtdLevelId = 0, AtdCategoryId = "S",  Name = "Білорусь" },
                new AtdUnit { Id = "MD", ParentId = null, AtdLevelId = 0, AtdCategoryId = "S",  Name = "Молдова" },
                new AtdUnit { Id = "RU", ParentId = null, AtdLevelId = 0, AtdCategoryId = "S",  Name = "Росія" },
                new AtdUnit { Id = "UA", ParentId = null, AtdLevelId = 0, AtdCategoryId = "S",  Name = "Україна" },

                // Области Украины
                new AtdUnit { Id = "UA05000000000010236", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O",  Name = "Вінницька" },
                new AtdUnit { Id = "UA07000000000024379", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O",  Name = "Волинська" },
                new AtdUnit { Id = "UA44000000000018893" /* UA-09 */, ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O",  Name = "Луганська" },
                //new AtdUnit { Id = "", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O",  Name = "" },
                //new AtdUnit { Id = "", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O",  Name = "" },
                //new AtdUnit { Id = "", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O",  Name = "" },
                //new AtdUnit { Id = "", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O",  Name = "" },
                //new AtdUnit { Id = "", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O",  Name = "" },
                //new AtdUnit { Id = "", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O",  Name = "" },
                //new AtdUnit { Id = "", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O",  Name = "" },
                //new AtdUnit { Id = "", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O",  Name = "" },
                //new AtdUnit { Id = "", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O",  Name = "" },
                //new AtdUnit { Id = "", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O",  Name = "" },
                //new AtdUnit { Id = "", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O",  Name = "" },
                //new AtdUnit { Id = "", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O",  Name = "" },
                //new AtdUnit { Id = "", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O",  Name = "" },
                //new AtdUnit { Id = "", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O",  Name = "" },
                //new AtdUnit { Id = "", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O",  Name = "" },
                //new AtdUnit { Id = "", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O",  Name = "" },
                //new AtdUnit { Id = "", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O",  Name = "" },
                //new AtdUnit { Id = "", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O",  Name = "" },
                //new AtdUnit { Id = "", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O",  Name = "" },
                //new AtdUnit { Id = "", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O",  Name = "" },
                //new AtdUnit { Id = "", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O",  Name = "" },
                //new AtdUnit { Id = "", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O",  Name = "" },
                //new AtdUnit { Id = "", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O",  Name = "" },
                //new AtdUnit { Id = "", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O",  Name = "" },
                //new AtdUnit { Id = "", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O",  Name = "" },
                //new AtdUnit { Id = "", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O",  Name = "" },
                //new AtdUnit { Id = "", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O",  Name = "" },
                //new AtdUnit { Id = "", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O",  Name = "" },
                //new AtdUnit { Id = "", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O",  Name = "" },
                //new AtdUnit { Id = "", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O",  Name = "" },
                //new AtdUnit { Id = "", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O",  Name = "" },
                //new AtdUnit { Id = "", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O",  Name = "" },
                //new AtdUnit { Id = "", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O",  Name = "" },
                //new AtdUnit { Id = "", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O",  Name = "" },
                //new AtdUnit { Id = "", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O",  Name = "" },
                //new AtdUnit { Id = "", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O",  Name = "" },
                //new AtdUnit { Id = "", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O",  Name = "" },
                //new AtdUnit { Id = "", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O",  Name = "" },
                //new AtdUnit { Id = "", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O",  Name = "" },
                //new AtdUnit { Id = "", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O",  Name = "" },
                //new AtdUnit { Id = "", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O",  Name = "" },
                //new AtdUnit { Id = "", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O",  Name = "" },
                //new AtdUnit { Id = "", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O",  Name = "" },
                //new AtdUnit { Id = "", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O",  Name = "" },
                //new AtdUnit { Id = "", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O",  Name = "" },
                //new AtdUnit { Id = "", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O",  Name = "" },
                //new AtdUnit { Id = "", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O",  Name = "" },
                //new AtdUnit { Id = "", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O",  Name = "" },
                //new AtdUnit { Id = "", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O",  Name = "" },
                //new AtdUnit { Id = "", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O",  Name = "" },
                //new AtdUnit { Id = "", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O",  Name = "" },
                //new AtdUnit { Id = "", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O",  Name = "" },
                //new AtdUnit { Id = "", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O",  Name = "" },
                //new AtdUnit { Id = "", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O",  Name = "" },
                //new AtdUnit { Id = "", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O",  Name = "" },

            };
        }
    }
}
