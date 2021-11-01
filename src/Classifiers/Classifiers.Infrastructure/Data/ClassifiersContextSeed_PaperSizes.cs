using CDPN.Classifiers.Entities;

namespace CDPN.Classifiers.Infrastructure.Data
{
    public partial class ClassifiersContextSeed
    {
        private static List<PaperSize> GetPreconfiguredPaperSizes()
        {
            return new List<PaperSize>()
            {
new PaperSize { Id = 100, Format = "A0",  Width =  841, Height = 1189, Use = "Технічні креслення, постери" },
new PaperSize { Id = 101, Format = "A1",  Width =  594, Height =  841, Use = "Технічні креслення, постери" },
new PaperSize { Id = 102, Format = "A2",  Width =  420, Height =  594, Use = "Креслення, діаграми, широкоформатні таблиці" },
new PaperSize { Id = 103, Format = "A3",  Width =  297, Height =  420, Use = "Креслення, діаграми, широкоформатні таблиці" },
new PaperSize { Id = 104, Format = "A4",  Width =  210, Height =  297, Use = "Листи, журнали, бланки, каталоги, витратні матеріали для принтерів та копірів" },
new PaperSize { Id = 105, Format = "A5",  Width =  148, Height =  210, Use = "Записні книжки, книги" },
new PaperSize { Id = 106, Format = "A6",  Width =  105, Height =  148, Use = "Поштові листівки, книги" },
new PaperSize { Id = 107, Format = "A7",  Width =   74, Height =  105, Use = "" },
new PaperSize { Id = 108, Format = "A8",  Width =   52, Height =   74, Use = "" },
new PaperSize { Id = 109, Format = "A9",  Width =   37, Height =   52, Use = "" },
new PaperSize { Id = 110, Format = "A10", Width =   26, Height =   37, Use = "" },
new PaperSize { Id = 200, Format = "B0",  Width = 1000, Height = 1414, Use = "" },
new PaperSize { Id = 201, Format = "B1",  Width =  707, Height = 1000, Use = "" },
new PaperSize { Id = 202, Format = "B2",  Width =  500, Height =  707, Use = "" },
new PaperSize { Id = 203, Format = "B3",  Width =  353, Height =  500, Use = "" },
new PaperSize { Id = 204, Format = "B4",  Width =  250, Height =  353, Use = "" },
new PaperSize { Id = 205, Format = "B5",  Width =  176, Height =  250, Use = "Книги" },
new PaperSize { Id = 206, Format = "B6",  Width =  125, Height =  176, Use = "Книги" },
new PaperSize { Id = 207, Format = "B7",  Width =   88, Height =  125, Use = "" },
new PaperSize { Id = 208, Format = "B8",  Width =   62, Height =   88, Use = "" },
new PaperSize { Id = 209, Format = "B9",  Width =   44, Height =   62, Use = "" },
new PaperSize { Id = 210, Format = "B10", Width =   31, Height =   44, Use = "" },
new PaperSize { Id = 300, Format = "C0",  Width =  917, Height = 1297, Use = "" },
new PaperSize { Id = 301, Format = "C1",  Width =  648, Height =  917, Use = "" },
new PaperSize { Id = 302, Format = "C2",  Width =  458, Height =  648, Use = "" },
new PaperSize { Id = 303, Format = "C3",  Width =  324, Height =  458, Use = "" },
new PaperSize { Id = 304, Format = "C4",  Width =  229, Height =  324, Use = "Конверти для листів формату A4 не складені" },
new PaperSize { Id = 305, Format = "C5",  Width =  162, Height =  229, Use = "Конверти для листів формату A4 складені вдвічі" },
new PaperSize { Id = 306, Format = "C6",  Width =  114, Height =  162, Use = "Конверти для листів формату A4 складені втричі або документів формату А6" },
new PaperSize { Id = 307, Format = "C7",  Width =   81, Height =  114, Use = "" },
new PaperSize { Id = 308, Format = "C8",  Width =   57, Height =   81, Use = "" },
new PaperSize { Id = 309, Format = "C9",  Width =   40, Height =   57, Use = "" },
new PaperSize { Id = 310, Format = "C10", Width =   28, Height =   40, Use = "" },

new PaperSize { Id = 311, Format = "C65", Width   =114, Height =  229, Use = "" },
new PaperSize { Id = 313, Format = "C6/C7", Width =114, Height =  229, Use = "" },
new PaperSize { Id = 315, Format = "C7/C6", Width = 81, Height =  162, Use = "" },

new PaperSize { Id = 411, Format = "DL",  Width =  110, Height =  220, Use = "(або E65) Євроконверт для листів формату A4 складені втричі" },
new PaperSize { Id = 511, Format = "Е65", Width =  110, Height =  220, Use = "(або DL) Євроконверт для листів формату A4 складені втричі" },
new PaperSize { Id = 513, Format = "E4",  Width =  280, Height =  400, Use = "" }
            };
        }
    }
}
