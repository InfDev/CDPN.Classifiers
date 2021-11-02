using CDPN.Common.Entities;
using System.Text.Json.Serialization;

namespace CDPN.Classifiers.Entities
{
    // https://uk.wikipedia.org/wiki/Класифікація_валют_(ISO_4217)
    // https://minfin.com.ua/currency/nbu/ - курсы валют

    /// <summary>
    /// Сущность "Валюта" согласно ISO 4217.
    /// </summary>
    public class Currency : BaseEntity
    {
        /// <summary>
        /// Идентификатор, соответствуют ISO 4217 alphabetic code
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Цифровой код по ISO 4217
        /// </summary>
        public int NumericCode { get; set; }

        /// <summary>
        /// Экспонента валюты с основанием 10, выражает взаимосвязь между основной единицей валюты и самой малой ее единицей.
        /// Например, доллар США равен 100 младших денежных единиц «центов» ( 1 доллар = 1E+02 центов).
        /// Также можно считать, что MinorUnit определяет  для валюты число десятичных знаков после запятой.
        /// </summary>
        public int? MinorUnit { get; set; }

        /// <summary>
        /// Группа валюты
        /// </summary>
        /// <remarks>Валюты с группой более 0 являются основными</remarks>
        public int Group { get; set; }

        /// <summary>
        /// Наименование валюты
        /// </summary>
        public string Name { get; set; }

        [JsonIgnore]
        public override string GetKey => Id;
    }
}
