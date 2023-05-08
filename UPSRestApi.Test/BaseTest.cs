using System.Configuration;
using Microsoft.Extensions.Configuration;
using UPSRestApi.Common;
using UPSRestApi.Models.Common;

namespace UPSRestApi.Test
{
    public abstract class BaseTest {
    protected string apiKey;
    protected string upsAccount = "";
    protected UpsClient client;
    protected Address shipFromAddress;

    [OneTimeSetUp]
    public void Init() {

      var config = new ConfigurationBuilder().
                       SetBasePath(TestContext.CurrentContext.TestDirectory).
                       AddJsonFile("appsettings.json").Build();

      this.shipFromAddress = new Address() { 
      AddressLine = config["ShipFromAddressLine"].ToString(),
      City = config["ShipFromCity"].ToString(),
      StateProvinceCode = config["ShipFromState"].ToString(),
      PostalCode = config["ShipFromZipcode"].ToString(),
      CountryCode = Common.Enums.Country.US
      };

      string clientId = config["clientId"].ToString();
      string clientSercret = config["clientSecret"].ToString();
      this.upsAccount = config["UPSAcount"].ToString();

      UpsOAuthClient.OAuthClient client = new(clientId, clientSercret, UpsOAuthClient.Common.Enums.ApiEnvironment.Test);
      var token = Task.Run(async () => await client.CreateToken()).GetAwaiter().GetResult();
      this.apiKey = token.AccessToken;

      this.client = new UPSRestApi.UpsClient(this.apiKey, Enums.Environment.Test);
    }
  }
}
