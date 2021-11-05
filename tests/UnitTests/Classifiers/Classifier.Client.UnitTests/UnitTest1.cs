using Xunit;
using CDPN.Classifiers.Client;

namespace CDPN.Classifier.Client.UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void GetUriTest()
        {
            var expected = "AtdUnits?Page=1&PageSize=50&Filter=Id%5EUA%2CAtdLevelId%3C2%2CName%21%2A%D0%BE%D0%BA%D1%83%D0%BF";
            var uri = ClassifiersClient.GetUri("AtdUnits", 1, 50, null, "Id^UA,AtdLevelId<2,Name!*окуп");
            Assert.Equal(expected, uri);
        }
    }
}