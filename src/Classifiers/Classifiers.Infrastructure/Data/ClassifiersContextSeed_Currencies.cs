﻿using CDPN.Classifiers.Entities;

namespace CDPN.Classifiers.Infrastructure.Data
{
    public partial class ClassifiersContextSeed
    {
        static IEnumerable<Currency> GetPreconfiguredCurrencies()
        {
            return new List<Currency>()
            {
                new Currency { Id = "AED", NumericCode = 784, MinorUnit = 2, Group = 0, Name = "Дирхам ОАЕ" },
                new Currency { Id = "AFN", NumericCode = 971, MinorUnit = 2, Group = 0, Name = "Афгані" },
                new Currency { Id = "ALL", NumericCode = 008, MinorUnit = 2, Group = 0, Name = "Лек" },
                new Currency { Id = "AMD", NumericCode = 051, MinorUnit = 2, Group = 0, Name = "Вірменський драм" },
                new Currency { Id = "ANG", NumericCode = 532, MinorUnit = 2, Group = 0, Name = "Гульден Нідерландських Антилів" },
                new Currency { Id = "AOA", NumericCode = 973, MinorUnit = 2, Group = 0, Name = "Кванза" },
                new Currency { Id = "ARS", NumericCode = 032, MinorUnit = 2, Group = 0, Name = "Аргентинське песо" },
                new Currency { Id = "AUD", NumericCode = 036, MinorUnit = 2, Group = 1, Name = "Австралійський долар" },
                new Currency { Id = "AWG", NumericCode = 533, MinorUnit = 2, Group = 0, Name = "Арубський флорин" },
                new Currency { Id = "AZN", NumericCode = 944, MinorUnit = 2, Group = 1, Name = "Азербайджанський манат" },

                new Currency { Id = "BAM", NumericCode = 977, MinorUnit = 2, Group = 0, Name = "Конвертовна марка" },
                new Currency { Id = "BBD", NumericCode = 052, MinorUnit = 2, Group = 0, Name = "Барбадоський долар" },
                new Currency { Id = "BDT", NumericCode = 050, MinorUnit = 2, Group = 0, Name = "Така" },
                new Currency { Id = "BGN", NumericCode = 975, MinorUnit = 2, Group = 1, Name = "Болгарський лев" },
                new Currency { Id = "BHD", NumericCode = 048, MinorUnit = 3, Group = 0, Name = "Бахрейнський динар" },
                new Currency { Id = "BIF", NumericCode = 108, MinorUnit = 0, Group = 0, Name = "Бурундійський франк" },
                new Currency { Id = "BMD", NumericCode = 060, MinorUnit = 2, Group = 0, Name = "Бермудський долар" },
                new Currency { Id = "BND", NumericCode = 096, MinorUnit = 2, Group = 0, Name = "Брунейський долар" },
                new Currency { Id = "BOB", NumericCode = 068, MinorUnit = 2, Group = 0, Name = "Болівіано" },
                new Currency { Id = "BOV", NumericCode = 984, MinorUnit = 2, Group = 0, Name = "Мвдол" },
                new Currency { Id = "BRL", NumericCode = 986, MinorUnit = 2, Group = 0, Name = "Бразильський реал" },
                new Currency { Id = "BSD", NumericCode = 044, MinorUnit = 2, Group = 0, Name = "Багамський долар" },
                new Currency { Id = "BTN", NumericCode = 064, MinorUnit = 2, Group = 0, Name = "Нґултрум" },
                new Currency { Id = "BWP", NumericCode = 072, MinorUnit = 2, Group = 0, Name = "Пула" },
                new Currency { Id = "BYN", NumericCode = 933, MinorUnit = 2, Group = 1, Name = "Білоруський рубль" },
                new Currency { Id = "BZD", NumericCode = 084, MinorUnit = 2, Group = 0, Name = "Белізький долар" },

                new Currency { Id = "CAD", NumericCode = 124, MinorUnit = 2, Group = 1, Name = "Канадський долар" },
                new Currency { Id = "CDF", NumericCode = 976, MinorUnit = 2, Group = 0, Name = "Конголезький франк" },
                new Currency { Id = "CHE", NumericCode = 947, MinorUnit = 2, Group = 0, Name = "Євро WIR" },
                new Currency { Id = "CHF", NumericCode = 756, MinorUnit = 2, Group = 2, Name = "Швейцарський франк" },
                new Currency { Id = "CHW", NumericCode = 948, MinorUnit = 2, Group = 0, Name = "Франк WIR" },
                new Currency { Id = "CLF", NumericCode = 990, MinorUnit = 4, Group = 0, Name = "Умовна розрахункова одиниця Чилі" },
                new Currency { Id = "CLP", NumericCode = 152, MinorUnit = 0, Group = 0, Name = "Чилійське песо" },
                new Currency { Id = "CNY", NumericCode = 156, MinorUnit = 2, Group = 1, Name = "Юань Женьмiньбi" },
                new Currency { Id = "COP", NumericCode = 170, MinorUnit = 2, Group = 0, Name = "Колумбійське песо" },
                new Currency { Id = "COU", NumericCode = 970, MinorUnit = 2, Group = 0, Name = "Одиниця реальної вартості" },
                new Currency { Id = "CRC", NumericCode = 188, MinorUnit = 2, Group = 0, Name = "Коста-риканський колон" },
                new Currency { Id = "CUC", NumericCode = 931, MinorUnit = 2, Group = 0, Name = "Кубинське конвертоване песо" },
                new Currency { Id = "CUP", NumericCode = 192, MinorUnit = 2, Group = 0, Name = "Кубинське песо" },
                new Currency { Id = "CVE", NumericCode = 132, MinorUnit = 2, Group = 0, Name = "Ескудо Кабо-Верде" },
                new Currency { Id = "CZK", NumericCode = 203, MinorUnit = 2, Group = 1, Name = "Чеська крона" },

                new Currency { Id = "DJF", NumericCode = 262, MinorUnit = 0, Group = 0, Name = "Джибутійський франк" },
                new Currency { Id = "DKK", NumericCode = 208, MinorUnit = 2, Group = 1, Name = "Данська крона" },
                new Currency { Id = "DOP", NumericCode = 214, MinorUnit = 2, Group = 0, Name = "Домініканське песо" },
                new Currency { Id = "DZD", NumericCode = 012, MinorUnit = 2, Group = 0, Name = "Алжирський динар" },

                new Currency { Id = "EGP", NumericCode = 818, MinorUnit = 2, Group = 1, Name = "Єгипетський фунт" },
                new Currency { Id = "ERN", NumericCode = 232, MinorUnit = 2, Group = 0, Name = "Накфа" },
                new Currency { Id = "ETB", NumericCode = 230, MinorUnit = 2, Group = 0, Name = "Ефіопський бир" },
                new Currency { Id = "EUR", NumericCode = 978, MinorUnit = 2, Group = 2, Name = "Євро" },

                new Currency { Id = "FJD", NumericCode = 242, MinorUnit = 2, Group = 0, Name = "Фіджійський долар" },
                new Currency { Id = "FKP", NumericCode = 238, MinorUnit = 2, Group = 0, Name = "Фолклендський фунт" },

                new Currency { Id = "GBP", NumericCode = 826, MinorUnit = 2, Group = 2, Name = "Фунт стерлінгів" },
                new Currency { Id = "GEL", NumericCode = 981, MinorUnit = 2, Group = 0, Name = "Ларі" },
                new Currency { Id = "GHS", NumericCode = 936, MinorUnit = 2, Group = 0, Name = "Ганський седі" },
                new Currency { Id = "GIP", NumericCode = 292, MinorUnit = 2, Group = 0, Name = "Ґібралтарський фунт" },
                new Currency { Id = "GMD", NumericCode = 270, MinorUnit = 2, Group = 0, Name = "Даласі" },
                new Currency { Id = "GNF", NumericCode = 324, MinorUnit = 0, Group = 0, Name = "Гвінейський франк" },
                new Currency { Id = "GTQ", NumericCode = 320, MinorUnit = 2, Group = 0, Name = "Кетсаль" },
                new Currency { Id = "GYD", NumericCode = 328, MinorUnit = 2, Group = 0, Name = "Гаянський долар" },

                new Currency { Id = "HKD", NumericCode = 344, MinorUnit = 2, Group = 1, Name = "Гонконгівський долар" },
                new Currency { Id = "HNL", NumericCode = 340, MinorUnit = 2, Group = 0, Name = "Лемпіра" },
                new Currency { Id = "HRK", NumericCode = 191, MinorUnit = 2, Group = 1, Name = "Хорватська куна" },
                new Currency { Id = "HTG", NumericCode = 332, MinorUnit = 2, Group = 0, Name = "Ґурд" },
                new Currency { Id = "HUF", NumericCode = 348, MinorUnit = 2, Group = 1, Name = "Форинт" },

                new Currency { Id = "IDR", NumericCode = 360, MinorUnit = 2, Group = 1, Name = "Рупія" },
                new Currency { Id = "ILS", NumericCode = 376, MinorUnit = 2, Group = 1, Name = "Новий ізраїльський шекель" },
                new Currency { Id = "INR", NumericCode = 356, MinorUnit = 2, Group = 1, Name = "Індійська рупія" },
                new Currency { Id = "IQD", NumericCode = 368, MinorUnit = 3, Group = 0, Name = "Іракський динар" },
                new Currency { Id = "IRR", NumericCode = 364, MinorUnit = 2, Group = 0, Name = "Іранський ріал" },
                new Currency { Id = "ISK", NumericCode = 352, MinorUnit = 0, Group = 0, Name = "Ісландська крона" },

                new Currency { Id = "JMD", NumericCode = 388, MinorUnit = 2, Group = 0, Name = "Ямайський долар" },
                new Currency { Id = "JOD", NumericCode = 400, MinorUnit = 3, Group = 0, Name = "Йорданський динар" },
                new Currency { Id = "JPY", NumericCode = 392, MinorUnit = 0, Group = 1, Name = "Єна" },

                new Currency { Id = "KES", NumericCode = 404, MinorUnit = 2, Group = 0, Name = "Кенійський шилінг" },
                new Currency { Id = "KGS", NumericCode = 417, MinorUnit = 2, Group = 0, Name = "Сом" },
                new Currency { Id = "KHR", NumericCode = 116, MinorUnit = 2, Group = 0, Name = "Ріел" },
                new Currency { Id = "KMF", NumericCode = 174, MinorUnit = 0, Group = 0, Name = "Коморський франк" },
                new Currency { Id = "KPW", NumericCode = 408, MinorUnit = 2, Group = 0, Name = "Північно-корейська вона" },
                new Currency { Id = "KRW", NumericCode = 410, MinorUnit = 0, Group = 1, Name = "Вона" },
                new Currency { Id = "KWD", NumericCode = 414, MinorUnit = 3, Group = 0, Name = "Кувейтський динар" },
                new Currency { Id = "KYD", NumericCode = 136, MinorUnit = 2, Group = 0, Name = "Долар Кайманових островів" },
                new Currency { Id = "KZT", NumericCode = 398, MinorUnit = 2, Group = 1, Name = "Теньґе" },

                new Currency { Id = "LAK", NumericCode = 418, MinorUnit = 2, Group = 0, Name = "Кіп" },
                new Currency { Id = "LBP", NumericCode = 422, MinorUnit = 2, Group = 0, Name = "Ліванський фунт" },
                new Currency { Id = "LKR", NumericCode = 144, MinorUnit = 2, Group = 0, Name = "Рупія Шрі-Ланки" },
                new Currency { Id = "LRD", NumericCode = 430, MinorUnit = 2, Group = 0, Name = "Ліберійський долар" },
                new Currency { Id = "LSL", NumericCode = 426, MinorUnit = 2, Group = 0, Name = "Лоті" },
                new Currency { Id = "LYD", NumericCode = 434, MinorUnit = 3, Group = 0, Name = "Лівійський динар" },

                new Currency { Id = "MAD", NumericCode = 504, MinorUnit = 2, Group = 0, Name = "Марокканський дирхам" },
                new Currency { Id = "MDL", NumericCode = 498, MinorUnit = 2, Group = 1, Name = "Молдовський лей" },
                new Currency { Id = "MGA", NumericCode = 969, MinorUnit = 2, Group = 0, Name = "Малагасійський аріарі" },
                new Currency { Id = "MKD", NumericCode = 807, MinorUnit = 2, Group = 0, Name = "Денар" },
                new Currency { Id = "MMK", NumericCode = 104, MinorUnit = 2, Group = 0, Name = "К'ят" },
                new Currency { Id = "MNT", NumericCode = 496, MinorUnit = 2, Group = 0, Name = "Тугрик" },
                new Currency { Id = "MOP", NumericCode = 446, MinorUnit = 2, Group = 0, Name = "Патака" },
                new Currency { Id = "MRO", NumericCode = 478, MinorUnit = 2, Group = 0, Name = "Уґія" },
                new Currency { Id = "MUR", NumericCode = 480, MinorUnit = 2, Group = 0, Name = "Маврикійська рупія" },
                new Currency { Id = "MVR", NumericCode = 462, MinorUnit = 2, Group = 0, Name = "Руфія" },
                new Currency { Id = "MWK", NumericCode = 454, MinorUnit = 2, Group = 0, Name = "Малавійська квача" },
                new Currency { Id = "MXN", NumericCode = 484, MinorUnit = 2, Group = 1, Name = "Мексиканське песо" },
                new Currency { Id = "MXV", NumericCode = 979, MinorUnit = 2, Group = 0, Name = "Мексиканська перерахункова одиниця" },
                new Currency { Id = "MYR", NumericCode = 458, MinorUnit = 2, Group = 0, Name = "Малайзійський рингіт" },
                new Currency { Id = "MZN", NumericCode = 943, MinorUnit = 2, Group = 0, Name = "Метикал" },

                new Currency { Id = "NAD", NumericCode = 516, MinorUnit = 2, Group = 0, Name = "Намібійський долар" },
                new Currency { Id = "NGN", NumericCode = 566, MinorUnit = 2, Group = 0, Name = "Найра" },
                new Currency { Id = "NIO", NumericCode = 558, MinorUnit = 2, Group = 0, Name = "Золота кордоба" },
                new Currency { Id = "NOK", NumericCode = 578, MinorUnit = 2, Group = 1, Name = "Норвезька крона" },
                new Currency { Id = "NPR", NumericCode = 524, MinorUnit = 2, Group = 0, Name = "Непальська рупія" },
                new Currency { Id = "NZD", NumericCode = 554, MinorUnit = 2, Group = 1, Name = "Новозеландський долар" },

                new Currency { Id = "OMR", NumericCode = 512, MinorUnit = 3, Group = 0, Name = "Оманський ріал" },

                new Currency { Id = "PAB", NumericCode = 590, MinorUnit = 2, Group = 0, Name = "Бальбоа" },
                new Currency { Id = "PEN", NumericCode = 604, MinorUnit = 2, Group = 0, Name = "Соль" },
                new Currency { Id = "PGK", NumericCode = 598, MinorUnit = 2, Group = 0, Name = "Кіна" },
                new Currency { Id = "PHP", NumericCode = 608, MinorUnit = 2, Group = 0, Name = "Філіппінський песо" },
                new Currency { Id = "PKR", NumericCode = 586, MinorUnit = 2, Group = 0, Name = "Пакистанська рупія" },
                new Currency { Id = "PLN", NumericCode = 985, MinorUnit = 2, Group = 2, Name = "Злотий" },
                new Currency { Id = "PYG", NumericCode = 600, MinorUnit = 0, Group = 0, Name = "Ґуарані" },

                new Currency { Id = "QAR", NumericCode = 634, MinorUnit = 2, Group = 0, Name = "Катарський ріал" },

                new Currency { Id = "RON", NumericCode = 946, MinorUnit = 2, Group = 1, Name = "Румунський лей" },
                new Currency { Id = "RSD", NumericCode = 941, MinorUnit = 2, Group = 0, Name = "Сербський динар" },
                new Currency { Id = "RUB", NumericCode = 643, MinorUnit = 2, Group = 2, Name = "Російський рубль" },
                new Currency { Id = "RWF", NumericCode = 646, MinorUnit = 0, Group = 0, Name = "Руандійський франк" },

                new Currency { Id = "SAR", NumericCode = 682, MinorUnit = 2, Group = 1, Name = "Саудівський ріял" },
                new Currency { Id = "SBD", NumericCode = 090, MinorUnit = 2, Group = 0, Name = "Долар Соломонових Островів" },
                new Currency { Id = "SCR", NumericCode = 690, MinorUnit = 2, Group = 0, Name = "Сейшельська рупія" },
                new Currency { Id = "SDG", NumericCode = 938, MinorUnit = 2, Group = 0, Name = "Суданський фунт" },
                new Currency { Id = "SEK", NumericCode = 752, MinorUnit = 2, Group = 1, Name = "Шведська крона" },
                new Currency { Id = "SGD", NumericCode = 702, MinorUnit = 2, Group = 1, Name = "Сінгапурський долар" },
                new Currency { Id = "SHP", NumericCode = 654, MinorUnit = 2, Group = 0, Name = "Фунт Святої Єлени" },
                new Currency { Id = "SLL", NumericCode = 694, MinorUnit = 2, Group = 0, Name = "Леоне" },
                new Currency { Id = "SOS", NumericCode = 706, MinorUnit = 2, Group = 0, Name = "Сомалійський шилінг" },
                new Currency { Id = "SRD", NumericCode = 968, MinorUnit = 2, Group = 0, Name = "Суринамський долар" },
                new Currency { Id = "SSP", NumericCode = 728, MinorUnit = 2, Group = 0, Name = "Південносуданський фунт" },
                new Currency { Id = "STD", NumericCode = 678, MinorUnit = 2, Group = 0, Name = "Добра" },
                new Currency { Id = "SVC", NumericCode = 222, MinorUnit = 2, Group = 0, Name = "Сальвадорський колон" },
                new Currency { Id = "SYP", NumericCode = 760, MinorUnit = 2, Group = 0, Name = "Сирійський фунт" },
                new Currency { Id = "SZL", NumericCode = 748, MinorUnit = 2, Group = 0, Name = "Ліланґені" },

                new Currency { Id = "THB", NumericCode = 764, MinorUnit = 2, Group = 0, Name = "Бат" },
                new Currency { Id = "TJS", NumericCode = 972, MinorUnit = 2, Group = 0, Name = "Сомоні" },
                new Currency { Id = "TMT", NumericCode = 934, MinorUnit = 2, Group = 0, Name = "Туркменський манат" },
                new Currency { Id = "TND", NumericCode = 788, MinorUnit = 3, Group = 0, Name = "Туніський динар" },
                new Currency { Id = "TOP", NumericCode = 776, MinorUnit = 2, Group = 0, Name = "Паанга" },
                new Currency { Id = "TRY", NumericCode = 949, MinorUnit = 2, Group = 1, Name = "Турецька ліра" },
                new Currency { Id = "TTD", NumericCode = 780, MinorUnit = 2, Group = 0, Name = "Долар Тринідаду і Тобаго" },
                new Currency { Id = "TWD", NumericCode = 901, MinorUnit = 2, Group = 0, Name = "Новий тайванський долар" },
                new Currency { Id = "TZS", NumericCode = 834, MinorUnit = 2, Group = 0, Name = "Танзанійський шилінг" },

                new Currency { Id = "UAH", NumericCode = 980, MinorUnit = 2, Group = 2, Name = "Гривня" },
                new Currency { Id = "UGX", NumericCode = 800, MinorUnit = 0, Group = 0, Name = "Угандійський шилінг" },
                new Currency { Id = "USD", NumericCode = 840, MinorUnit = 2, Group = 2, Name = "Долар США" },
                new Currency { Id = "USN", NumericCode = 997, MinorUnit = 2, Group = 0, Name = "Долар США (наступного дня)" },
                new Currency { Id = "UYI", NumericCode = 940, MinorUnit = 0, Group = 0, Name = "Уругвайське конвертоване песо" },
                new Currency { Id = "UYU", NumericCode = 858, MinorUnit = 2, Group = 0, Name = "Уругвайський песо" },
                new Currency { Id = "UZS", NumericCode = 860, MinorUnit = 2, Group = 0, Name = "Узбецький сум" },

                new Currency { Id = "VEF", NumericCode = 937, MinorUnit = 2, Group = 0, Name = "Болівар" },
                new Currency { Id = "VND", NumericCode = 704, MinorUnit = 0, Group = 0, Name = "Донг" },
                new Currency { Id = "VUV", NumericCode = 548, MinorUnit = 0, Group = 0, Name = "Вату" },

                new Currency { Id = "WST", NumericCode = 882, MinorUnit = 2, Group = 0, Name = "Тала" },

                new Currency { Id = "XAF", NumericCode = 950, MinorUnit = 0, Group = 0, Name = "Франк CFA-BEAC" },
                new Currency { Id = "XAG", NumericCode = 961, MinorUnit = null, Group = 0, Name = "Срібло" },
                new Currency { Id = "XAU", NumericCode = 959, MinorUnit = null, Group = 0, Name = "Золото" },
                new Currency { Id = "XBA", NumericCode = 955, MinorUnit = null, Group = 0, Name = "Європейська складена валютна одиниця (EURCO)" },
                new Currency { Id = "XBB", NumericCode = 956, MinorUnit = null, Group = 0, Name = "Європейська грошова одиниця (E.M.U.-6)" },
                new Currency { Id = "XBC", NumericCode = 957, MinorUnit = null, Group = 0, Name = "Європейська розрахункова одиниця (E.U.A.-9)" },
                new Currency { Id = "XBD", NumericCode = 958, MinorUnit = null, Group = 0, Name = "Європейська розрахункова одиниця (E.U.A.-17)" },
                new Currency { Id = "XCD", NumericCode = 951, MinorUnit = 2, Group = 0, Name = "Східнокарибський долар" },
                new Currency { Id = "XDR", NumericCode = 960, MinorUnit = null, Group = 1, Name = "СПЗ (спеціальні права запозичення)" },
                new Currency { Id = "XOF", NumericCode = 952, MinorUnit = 0, Group = 0, Name = "Франк CFA-BCEAO" },
                new Currency { Id = "XPD", NumericCode = 964, MinorUnit = null, Group = 0, Name = "Паладій" },
                new Currency { Id = "XPF", NumericCode = 953, MinorUnit = 0, Group = 0, Name = "Франк CFP" },
                new Currency { Id = "XPT", NumericCode = 962, MinorUnit = null, Group = 0, Name = "Платина" },
                new Currency { Id = "XSU", NumericCode = 994, MinorUnit = null, Group = 0, Name = "Сукре" },
                new Currency { Id = "XTS", NumericCode = 963, MinorUnit = null, Group = 0, Name = "Резервні коди спеціального призначення" },
                new Currency { Id = "XUA", NumericCode = 965, MinorUnit = null, Group = 0, Name = "Одиниця рахунку АфБР" },
                new Currency { Id = "XXX", NumericCode = 999, MinorUnit = null, Group = 0, Name = "Коди, призначені для контрактів, у яких немає посилань на валюти" },

                new Currency { Id = "YER", NumericCode = 886, MinorUnit = 2, Group = 0, Name = "Єменський ріал" },

                new Currency { Id = "ZAR", NumericCode = 710, MinorUnit = 2, Group = 1, Name = "Ренд" },
                new Currency { Id = "ZMW", NumericCode = 967, MinorUnit = 2, Group = 0, Name = "Замбійська квача" },
                new Currency { Id = "ZWL", NumericCode = 932, MinorUnit = 2, Group = 0, Name = "Зімбабвійський долар" },
            };
        }
    }
}
