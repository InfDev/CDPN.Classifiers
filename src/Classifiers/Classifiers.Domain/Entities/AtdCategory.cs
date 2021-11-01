using CDPN.Common.Entities;
using System.Collections.Generic;

namespace CDPN.Classifiers.Entities
{
    // ідентифікаційні коди об’єктів кодифікатора
    // https://atu.decentralization.gov.ua/static/%D0%86%D0%B4%D0%B5%D0%BD%D1%82%D0%B8%D1%84%D1%96%D0%BA%D0%B0%D1%86%D1%96%D0%B9%D0%BD%D1%96%20%D0%BA%D0%BE%D0%B4%D0%B8%20%D0%BE%D0%B1'%D1%94%D0%BA%D1%82%D1%96%D0%B2%20%D0%9A%D0%BE%D0%B4%D0%B8%D1%84%D1%96%D0%BA%D0%B0%D1%82%D0%BE%D1%80%D0%B0%20(%D0%BD%D0%B0%D0%BA%D0%B0%D0%B7%20%E2%84%963%20%D0%B2%D1%96%D0%B4%2012.01.2021).xlsx
    /// <summary>
    /// Сущность "Категория административно-территориального деления"
    /// </summary>
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
