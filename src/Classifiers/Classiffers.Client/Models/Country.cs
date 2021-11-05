
namespace CDPN.Classifiers.Client.Models
{
    public class Country
    {
        public string Id { get; set; }
        public string Alpha3 { get; set; }
         public int NumericCode { get; set; }
        public int Group { get; set; }
        public string Name { get; set; }
        public string CurrencyId { get; set; }
    }
}
