// Copyright (c) Alexander Shlyakhto (InfDev). All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using CDPN.Common.Entities;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CDPN.Classifiers.Entities
{
    // Адміністративно-територіальний устрій України:
    // https://www.minregion.gov.ua/napryamki-diyalnosti/rozvytok-mistsevoho-samovryaduvannya/administratyvno/
    // ІНТЕРАКТИВНА МАПА. АДМІНІСТРАТИВНО-ТЕРИТОРІАЛЬНИХ ОДИНИЦЬ УКРАЇНИ
    // https://atu.decentralization.gov.ua/
    /// <summary>
    /// Сущность "Уровень региона"
    /// </summary>
    public class RegionLevel : BaseEntity
    {
        /// <summary>
        /// Идентификатор соответствует коду по КОАТУУ
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }

       [JsonIgnore]
        public override string GetKey => Id.ToString();

        /// <summary>
        /// Список регионов
        /// </summary>
        public ICollection<Region> Regions { get; set; }
    }
}
