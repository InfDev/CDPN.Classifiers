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
                // 0 уровень: страны (Id - 2-х символьный код страны по ISO 3166-2)
                new AtdUnit { Id = "AE", ParentId = null, AtdLevelId = 0, AtdCategoryId = "S", Name = "ОАЕ" },
                new AtdUnit { Id = "BG", ParentId = null, AtdLevelId = 0, AtdCategoryId = "S", Name = "Болгарія" },
                new AtdUnit { Id = "BY", ParentId = null, AtdLevelId = 0, AtdCategoryId = "S", Name = "Білорусь" },
                new AtdUnit { Id = "CA", ParentId = null, AtdLevelId = 0, AtdCategoryId = "S", Name = "Канада" },
                new AtdUnit { Id = "CH", ParentId = null, AtdLevelId = 0, AtdCategoryId = "S", Name = "Швейцарія" },
                new AtdUnit { Id = "CN", ParentId = null, AtdLevelId = 0, AtdCategoryId = "S", Name = "КНР" },
                new AtdUnit { Id = "DE", ParentId = null, AtdLevelId = 0, AtdCategoryId = "S", Name = "Німеччина" },
                new AtdUnit { Id = "EE", ParentId = null, AtdLevelId = 0, AtdCategoryId = "S", Name = "Естонія" },
                new AtdUnit { Id = "EG", ParentId = null, AtdLevelId = 0, AtdCategoryId = "S", Name = "Єгипет" },
                new AtdUnit { Id = "ES", ParentId = null, AtdLevelId = 0, AtdCategoryId = "S", Name = "Іспанія" },
                new AtdUnit { Id = "FR", ParentId = null, AtdLevelId = 0, AtdCategoryId = "S", Name = "Франція" },
                new AtdUnit { Id = "GB", ParentId = null, AtdLevelId = 0, AtdCategoryId = "S", Name = "Велика Британія" },
                new AtdUnit { Id = "GE", ParentId = null, AtdLevelId = 0, AtdCategoryId = "S", Name = "Грузія" },
                new AtdUnit { Id = "GR", ParentId = null, AtdLevelId = 0, AtdCategoryId = "S", Name = "Греція" },
                new AtdUnit { Id = "HU", ParentId = null, AtdLevelId = 0, AtdCategoryId = "S", Name = "Угорщина" },
                new AtdUnit { Id = "IL", ParentId = null, AtdLevelId = 0, AtdCategoryId = "S", Name = "Ізраїль" },
                new AtdUnit { Id = "IN", ParentId = null, AtdLevelId = 0, AtdCategoryId = "S", Name = "Індія" },
                new AtdUnit { Id = "JP", ParentId = null, AtdLevelId = 0, AtdCategoryId = "S", Name = "Японія" },
                new AtdUnit { Id = "IT", ParentId = null, AtdLevelId = 0, AtdCategoryId = "S", Name = "Італія" },
                new AtdUnit { Id = "KZ", ParentId = null, AtdLevelId = 0, AtdCategoryId = "S", Name = "Казахстан" },
                new AtdUnit { Id = "LT", ParentId = null, AtdLevelId = 0, AtdCategoryId = "S", Name = "Литва" },
                new AtdUnit { Id = "LV", ParentId = null, AtdLevelId = 0, AtdCategoryId = "S", Name = "Латвія" },
                new AtdUnit { Id = "MD", ParentId = null, AtdLevelId = 0, AtdCategoryId = "S", Name = "Молдова" },
                new AtdUnit { Id = "NO", ParentId = null, AtdLevelId = 0, AtdCategoryId = "S", Name = "Норвегія" },
                new AtdUnit { Id = "PL", ParentId = null, AtdLevelId = 0, AtdCategoryId = "S", Name = "Польща" },
                new AtdUnit { Id = "RO", ParentId = null, AtdLevelId = 0, AtdCategoryId = "S", Name = "Румунія" },
                new AtdUnit { Id = "PT", ParentId = null, AtdLevelId = 0, AtdCategoryId = "S", Name = "Португалія" },
                new AtdUnit { Id = "RU", ParentId = null, AtdLevelId = 0, AtdCategoryId = "S", Name = "Росія" },
                new AtdUnit { Id = "SK", ParentId = null, AtdLevelId = 0, AtdCategoryId = "S", Name = "Словаччина" },
                new AtdUnit { Id = "TR", ParentId = null, AtdLevelId = 0, AtdCategoryId = "S", Name = "Туреччина" },
                new AtdUnit { Id = "UA", ParentId = null, AtdLevelId = 0, AtdCategoryId = "S", Name = "Україна" },
                new AtdUnit { Id = "US", ParentId = null, AtdLevelId = 0, AtdCategoryId = "S", Name = "США" },

                // 1 уровень: области и спец. города Украины 
                new AtdUnit { Id = "UA01000000000013043" /* UA-43 */, ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O", Name = "Автономна Республіка Крим (тимчасово окуповано)" },
                new AtdUnit { Id = "UA05000000000010236", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O", Name = "Вінницька" },
                new AtdUnit { Id = "UA07000000000024379", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O", Name = "Волинська" },
                new AtdUnit { Id = "UA12000000000090473", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O", Name = "Дніпропетровська" },
                new AtdUnit { Id = "UA14000000000091971", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O", Name = "Донецька" },
                new AtdUnit { Id = "UA18000000000041385", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O", Name = "Житомирська" },
                new AtdUnit { Id = "UA21000000000011690", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O", Name = "Закарпатська" },
                new AtdUnit { Id = "UA23000000000064947", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O", Name = "Запорізька" },
                new AtdUnit { Id = "UA26000000000069363", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O", Name = "Івано-Франківська" },
                new AtdUnit { Id = "UA32000000000030281", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O", Name = "Київська" },
                new AtdUnit { Id = "UA35000000000016081", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O", Name = "Кіровоградська" },
                new AtdUnit { Id = "UA44000000000018893" /* UA-09 */, ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O", Name = "Луганська" },
                new AtdUnit { Id = "UA46000000000026241", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O", Name = "Львівська" },
                new AtdUnit { Id = "UA48000000000039575", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O", Name = "Миколаївська" },
                new AtdUnit { Id = "UA51000000000030770", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O", Name = "Одеська" },
                new AtdUnit { Id = "UA53000000000028050", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O", Name = "Полтавська" },
                new AtdUnit { Id = "UA56000000000066151" /* UA-19 */, ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O", Name = "Рівненська" },

                new AtdUnit { Id = "UA59000000000057109", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O", Name = "Сумська" },
                new AtdUnit { Id = "UA61000000000060328", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O", Name = "Тернопільська" },
                new AtdUnit { Id = "UA63000000000041885", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O", Name = "Харківська" },
                new AtdUnit { Id = "UA65000000000030969", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O", Name = "Херсонська" },
                new AtdUnit { Id = "UA68000000000099709", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O", Name = "Хмельницька" },
                new AtdUnit { Id = "UA71000000000010357", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O", Name = "Черкаська" },
                new AtdUnit { Id = "UA73000000000044923" /* UA-77 */, ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O", Name = "Чернівецька" },
                new AtdUnit { Id = "UA74000000000025378", ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "O", Name = "Чернігівська" },

                new AtdUnit { Id = "UA80000000000093317" /* UA-30 */, ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "K", Name = "Київ" },
                new AtdUnit { Id = "UA85000000000065278", /* UA-40 */ ParentId = "UA", AtdLevelId = 1, AtdCategoryId = "K", Name = "Севастополь (тимчасово окуповано)" },
            };
        }
    }
}
