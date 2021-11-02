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
        /// Идентификатор, соответствуют ISO 3166-1 numeric 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Код страны по ISO 3166-1 alpha-2
        /// </summary>
        //[Required(AllowEmptyStrings = false, ErrorMessage = "Двухбуквенный код страны обязателен"), StringLength(2, MinimumLength = 2, ErrorMessage = "Трехбуквенный код страны должен состоять из 2-х символов")]
        //[Display(Name = "Alpha-2")]
        public string Alpha2 { get; set; }

        /// <summary>
        /// Код страны по ISO 3166-1 alpha-3
        /// </summary>
        //[Required(AllowEmptyStrings = false, ErrorMessage = "Трехбуквенный код страны обязателен"), StringLength(3, MinimumLength = 3, ErrorMessage = "Трехбуквенный код страны должен состоять из 3-х символов")]
        //[Display(Name = "Alpha-3")]
        public string Alpha3 { get; set; }

        /// <summary>
        /// Группа страны
        /// </summary>
        /// <remarks>Страны с группой более 0 являются основными</remarks>
        public int Group { get; set; }

        /// <summary>
        /// Наименование страны
        /// </summary>
        //[Required(AllowEmptyStrings = false, ErrorMessage = "Наименование страны обязательно"), StringLength(100, MinimumLength = 3, ErrorMessage = "Длина наименования страны должна быть в диапазоне 3..100")]
        //[Display(Name = "Наименование")]
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
        public string GetGeoCodesIso => "ISO 3166-2:" + Alpha2;

        [JsonIgnore]
        public override string GetKey => Id.ToString();
    }
}
