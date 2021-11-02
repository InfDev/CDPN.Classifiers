using CDPN.Common.Entities;
using System.Text.Json.Serialization;

namespace CDPN.Classifiers.Entities
{
    /// <summary>
    /// Сущность "Страна" согласно ISO 3166-1 numeric, alpha-2, alpha-3.
    /// </summary>
    public class Country : BaseEntity
    {
        /// <summary>
        /// Идентификатор, соответствуют ISO 3166-1 alpha2 
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Код страны по ISO 3166-1 alpha-3
        /// </summary>
        public string Alpha3 { get; set; }

        /// <summary>
        /// Код страны по ISO 3166-1 numeric code
        /// </summary>
         public int NumericCode { get; set; }

        /// <summary>
        /// Группа страны
        /// </summary>
        /// <remarks>Страны с группой более 0 являются основными</remarks>
        public int Group { get; set; }

        /// <summary>
        /// Наименование страны
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Идентификатор валюты.
        /// Соответствует символьному коду по ISO 4217
        /// </summary>
        public string CurrencyId { get; set; }

        /// <summary>
        /// Cтандарт ISО для геокодов страны
        /// </summary>
        //[Display(Name = "Геокоды страны по ISO")]
        [JsonIgnore]
        public string GetIsoGeoCode => "ISO 3166-2:" + Id;

        [JsonIgnore]
        public override string GetKey => Id;
    }
}
