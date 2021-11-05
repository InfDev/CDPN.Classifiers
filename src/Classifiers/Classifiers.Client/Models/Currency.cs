
namespace CDPN.Classifiers.Client.Models
{
    public class Currency
    {
        public string Id { get; set; }
        public int NumericCode { get; set; }
        public int? MinorUnit { get; set; }
        public int Group { get; set; }
        public string Name { get; set; }
    }
}
