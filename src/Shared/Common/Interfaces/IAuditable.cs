using System;

namespace CDPN.Common.Interfaces
{
    public interface IAuditable
    {
        DateTimeOffset CreatedOn { get; set; }
        string CreatedBy { get; set; }
        DateTimeOffset ChangedOn { get; set; }
        string ChangedBy { get; set; }
    }
}
