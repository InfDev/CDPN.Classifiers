// Copyright (c) Alexander Shlyakhto (InfDev). All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using CDPN.Common.Entities;

namespace CDPN.Classifiers.Entities
{
    /// <summary>
    /// Сущность "Размер бумаги и конвертов" по стандарту ISO 216 и ISO 269
    /// </summary>
    public class PaperSize : IntKeyEntity
    {
        /// <summary>
        /// Формат
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// Ширина
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Высота
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Назначение
        /// </summary>
        public string Use { get; set; }

    }
}
