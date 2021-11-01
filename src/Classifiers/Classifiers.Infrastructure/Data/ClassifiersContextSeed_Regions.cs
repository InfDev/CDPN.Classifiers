using CDPN.Classifiers.Entities;

namespace CDPN.Classifiers.Infrastructure.Data
{
    public partial class ClassifiersContextSeed
    {
        private static List<Region> GetPreconfiguredRegions()
        {
            // Класифікатор об'єктів адміністративно-територіального устрою України
            // !! http://www.ukrstat.gov.ua/klasf/st_kls/op_koatuu_2016.htm
            // http://static.rada.gov.ua/zakon/new/NEWSAIT/ADM/zmist.html - Адміністративно-територіальний устрій
            // https://uk.wikipedia.org/wiki/Класифікатор_об%27єктів_адміністративно-територіального_устрою_України
            // https://data.gov.ua/en/dataset/dc081fb0-f504-4696-916c-a5b24312ab6e
            return new List<Region>()
            {
new Region { Id = "BY", CountryId = 112, RegionLevelId = 0, CountryClassifierId = "", Name = "Білорусь", Center = "Мінськ" },
new Region { Id = "MD", CountryId = 498, RegionLevelId = 0, CountryClassifierId = "", Name = "Молдова", Center = "Кишинів" },
new Region { Id = "RU", CountryId = 643, RegionLevelId = 0, CountryClassifierId = "", Name = "Росія", Center = "Москва" },
new Region { Id = "UA", CountryId = 804, RegionLevelId = 0, CountryClassifierId = "", Name = "Україна", Center = "Київ" },
new Region { Id = "UA-05", CountryId = 804, RegionLevelId = 1, CountryClassifierId = "05", Name = "Вінницька область", Center = "Вінниця" },
new Region { Id = "UA-07", CountryId = 804, RegionLevelId = 1, CountryClassifierId = "07", Name = "Волинська область", Center = "Луцьк" },
new Region { Id = "UA-09", CountryId = 804, RegionLevelId = 1, CountryClassifierId = "44", Name = "Луганська область", Center = "Луганськ" },
new Region { Id = "UA-12", CountryId = 804, RegionLevelId = 1, CountryClassifierId = "12", Name = "Дніпропетровська область", Center = "Дніпро" },
new Region { Id = "UA-14", CountryId = 804, RegionLevelId = 1, CountryClassifierId = "14", Name = "Донецька область", Center = "Донецьк" },
new Region { Id = "UA-18", CountryId = 804, RegionLevelId = 1, CountryClassifierId = "18", Name = "Житомирська область", Center = "Житомир" },
new Region { Id = "UA-19", CountryId = 804, RegionLevelId = 1, CountryClassifierId = "56", Name = "Рівненська область", Center = "Рівне" },
new Region { Id = "UA-21", CountryId = 804, RegionLevelId = 1, CountryClassifierId = "21", Name = "Закарпатська область", Center = "Ужгород" },
new Region { Id = "UA-23", CountryId = 804, RegionLevelId = 1, CountryClassifierId = "23", Name = "Запорізька область", Center = "Запоріжжя" },
new Region { Id = "UA-26", CountryId = 804, RegionLevelId = 1, CountryClassifierId = "26", Name = "Івано-Франківська область", Center = "Івано-Франківськ" },
new Region { Id = "UA-30", CountryId = 804, RegionLevelId = 1, CountryClassifierId = "80", Name = "Київ", Center = "Київ" },
new Region { Id = "UA-32", CountryId = 804, RegionLevelId = 1, CountryClassifierId = "32", Name = "Київська область", Center = "Київ" },
new Region { Id = "UA-35", CountryId = 804, RegionLevelId = 1, CountryClassifierId = "35", Name = "Кіровоградська область", Center = "Кропивницький" },
new Region { Id = "UA-40", CountryId = 804, RegionLevelId = 1, CountryClassifierId = "85", Name = "Севастополь", Center = "Севастополь" },
new Region { Id = "UA-43", CountryId = 804, RegionLevelId = 1, CountryClassifierId = "01", Name = "Автономна Республіка Крим", Center = "Сімферополь" },
new Region { Id = "UA-46", CountryId = 804, RegionLevelId = 1, CountryClassifierId = "46", Name = "Львівська область", Center = "Львів" },
new Region { Id = "UA-48", CountryId = 804, RegionLevelId = 1, CountryClassifierId = "48", Name = "Миколаївська область", Center = "Миколаїв" },
new Region { Id = "UA-51", CountryId = 804, RegionLevelId = 1, CountryClassifierId = "51", Name = "Одеська область", Center = "Одеса" },
new Region { Id = "UA-53", CountryId = 804, RegionLevelId = 1, CountryClassifierId = "53", Name = "Полтавська область", Center = "Полтава" },
new Region { Id = "UA-59", CountryId = 804, RegionLevelId = 1, CountryClassifierId = "59", Name = "Сумська область", Center = "Суми" },
new Region { Id = "UA-61", CountryId = 804, RegionLevelId = 1, CountryClassifierId = "61", Name = "Тернопільська область", Center = "Тернопіль" },
new Region { Id = "UA-63", CountryId = 804, RegionLevelId = 1, CountryClassifierId = "63", Name = "Харківська область", Center = "Харків" },
new Region { Id = "UA-65", CountryId = 804, RegionLevelId = 1, CountryClassifierId = "65", Name = "Херсонська область", Center = "Херсон" },
new Region { Id = "UA-68", CountryId = 804, RegionLevelId = 1, CountryClassifierId = "68", Name = "Хмельницька область", Center = "Хмельницький" },
new Region { Id = "UA-71", CountryId = 804, RegionLevelId = 1, CountryClassifierId = "71", Name = "Черкаська область", Center = "Черкаси" },
new Region { Id = "UA-74", CountryId = 804, RegionLevelId = 1, CountryClassifierId = "74", Name = "Чернігівська область", Center = "Чернігів" },
new Region { Id = "UA-77", CountryId = 804, RegionLevelId = 1, CountryClassifierId = "73", Name = "Чернівецька область", Center = "Чернівці" }
            };
        }
    }
}
