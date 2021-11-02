using System;
using System.Text.Json.Serialization;

namespace CDPN.Common.Entities
{
    public abstract class BaseEntity
    {
        /// <summary>
        /// Строковое представления ключа/идентификатора
        /// </summary>
        [JsonIgnore]
        public virtual string GetKey => string.Empty;
    }

    public class IntKeyEntity : BaseEntity
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }
        
        [JsonIgnore]
        public override string GetKey => Id.ToString();
    }

    public class LongKeyEntity : BaseEntity
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public long Id { get; set; }

        [JsonIgnore]
        public override string GetKey => Id.ToString();
    }

    public class StringKeyEntity : BaseEntity
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public string Id { get; set; }

        [JsonIgnore]
        public override string GetKey => Id;
    }

    public class GuidKeyEntity : BaseEntity
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        [JsonIgnore]
        public override string GetKey => Id.ToString();
    }

}
