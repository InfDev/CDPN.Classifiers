using CDPN.Common.Entities;
using System.Collections.Generic;

namespace CDPN.Classifiers.Entities
{
    // 
    /// <summary>
    /// Сущность "Уровень административно-территориальной единицы"
    /// </summary>
    public class AdminTerritorialLevel : BaseEntity
    {
        /// <summary>
        /// Идентификатор соответствует коду уровню по КОАТУУ
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }

        public override string GetKey => Id.ToString();

        /// <summary>
        /// Список регионов
        /// </summary>
        public ICollection<Region> Regions { get; set; }
    }
}
