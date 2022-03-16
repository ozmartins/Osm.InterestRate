using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Osm.InterestRate.Api;
using Osm.InterestRate.Domain;
using Osm.InterestRate.Domain.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace Osm.InterestRate.IntegrationTest
{
    [TestClass]
    public class InterestRateTest
    {
        private HttpClient _client;
        private TestServer _server;

        public InterestRateTest()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [TestMethod]
        public async Task GettingValidInteresRate()
        {
            #region arrange
            var targetUrl = "/TaxaJuros";
            #endregion

            #region act
            var responseMessage = await _client.GetAsync(targetUrl);
            var content = await responseMessage.Content.ReadAsStringAsync();
            var interestRate = JsonConvert.DeserializeObject<InterestRateModel>(content);
            #endregion

            #region assert
            Assert.IsTrue(responseMessage.IsSuccessStatusCode);
            Assert.AreEqual(interestRate.Value, Constants.DefaultInterestRate);
            #endregion            
        }
    }
}
