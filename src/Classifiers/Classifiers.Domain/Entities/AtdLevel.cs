using CDPN.Common.Entities;
using System.Collections.Generic;

namespace CDPN.Classifiers.Entities
{
    /// <summary>
    /// Сущность "Уровень административно-территориального деления"
    /// </summary>
    /// <remarks>Адміністративно-територіальний устрій України: https://atu.decentralization.gov.ua/</remarks>
    public class AtdLevel : BaseEntity
    {
        /// <summary>
        /// Идентификатор соответствует коду уровню по КОАТУУ
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Начальный индекс в идентификаторе единицы АТО
        /// </summary>

        public int InUnitIdStartIndex { get; set; }
        /// <summary>
        /// Конечный индекс в идентификаторе единицы АТО
        /// </summary>
        public int InUnitIdStoptIndex { get; set; }

        public ICollection<AtdUnit> AtdUnits { get; set; }

        public override string GetKey => Id.ToString();
    }
}
