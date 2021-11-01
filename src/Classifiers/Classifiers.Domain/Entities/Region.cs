// Copyright (c) Alexander Shlyakhto (InfDev). All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using CDPN.Common.Entities;

// ІНТЕРАКТИВНА МАПА. АДМІНІСТРАТИВНО - ТЕРИТОРІАЛЬНИХ ОДИНИЦЬ УКРАЇНИ
// https://atu.decentralization.gov.ua/

namespace CDPN.Classifiers.Entities
{
    /// <summary>
    /// Сущность "Регион"
    /// </summary>
    public class Region : BaseEntity
    {
        /// <summary>
        /// Идентификатор региона по ISO 3166-2
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Идентификатор страны по ISO 3166-1 numeric
        /// </summary>
        public int CountryId { get; set; }

        /// <summary>
        /// Идентификатор уровня административно-территориального устройства
        /// </summary>
        public int RegionLevelId { get; set; }

        ///// <summary>
        ///// Уровень административно-территориального устройства
        ///// </summary>
        //public RegionLevel RegionLevel { get; set; }

        /// <summary>
        /// Идентификатор по классификатору страны
        /// </summary>
        public string CountryClassifierId { get; set; }

        /// <summary>
        /// Наименование региона
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Центр административно-территориальной единицы
        /// </summary>
        public string Center { get; set; }

        public RegionLevel RegionLevel { get; set; }

        public override string GetKey => Id;
    }
}
