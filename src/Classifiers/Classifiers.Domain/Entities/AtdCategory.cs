using CDPN.Common.Entities;
using System.Collections.Generic;

namespace CDPN.Classifiers.Entities
{
    /// <summary>
    /// Сущность "Категория административно-территориального деления"
    /// </summary>
    /// <remarks>Адміністративно-територіальний устрій України: https://atu.decentralization.gov.ua/</remarks>
    public class AtdCategory : BaseEntity
    {
        /// <summary>
        /// Идентификатор категории
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Список единиц АТО
        /// </summary>
        public ICollection<AtdUnit> AtdUnits { get; set; }

        public override string GetKey => Id;
    }
}
