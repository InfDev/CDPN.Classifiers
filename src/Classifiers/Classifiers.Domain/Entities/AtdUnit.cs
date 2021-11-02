using CDPN.Common.Entities;
using System.Collections.Generic;

namespace CDPN.Classifiers.Entities
{
    /// <summary>
    /// Сущность "Единица административно-территориального деления"
    /// </summary>
    /// <remarks>Адміністративно-територіальний устрій України: https://atu.decentralization.gov.ua/. 
    /// АТУ, англ. Atd - Administrative and territorial divisions)
    /// </remarks>
    public class AtdUnit : BaseEntity
    {
        /// <summary>
        /// Идентификатор соответствует коду по КОАТУУ
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Идентификатор родителя
        /// </summary>
        public string ParentId { get; set; }

        /// <summary>
        /// Идентификатор уровня
        /// </summary>
        public int AtdLevelId { get; set; }

        /// <summary>
        /// Идентификатор категории
        /// </summary>
        public string AtdCategoryId { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Уровень
        /// </summary>
        public AtdLevel AtdLevel { get; set; }

        /// <summary>
        /// Категория
        /// </summary>
        public AtdCategory AtdCategory { get; set; }

        /// <summary>
        /// Родитель
        /// </summary>
        public AtdUnit Parent { get; set; }

        /// <summary>
        /// Дочерние единицы
        /// </summary>
        public ICollection<AtdUnit> Childrens { get; set; }

        public string GetCountryAlpha2 => Id?.Substring(0, 1);

        public override string GetKey => Id;
    }
}
