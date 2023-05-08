using UPSRestApi.Common;

namespace UPSRestApi.Test.HttpTests {
  [TestFixture]
  public class ClientConfigurationTest {
    [Test]
    [TestCase(Enums.Environment.Test, "https://wwwcie.ups.com/")]
    [TestCase(Enums.Environment.Production, "https://onlinetools.ups.com/")]
    public void ApiBaseUrl_RetrieveUrlMatchingEnvironment_WhenAddEnvironmentInConstructor(Enums.Environment mode, string validUrl) {
      UPSRestApi.Http.ClientConfiguration clientConfiguration = new("test key", mode);
      Assert.That(clientConfiguration.ApiBaseUrl, Is.EqualTo(validUrl));
    }

    [Test]
    [TestCase(Enums.Environment.Test, "https://wwwcie.ups.com/")]
    [TestCase(Enums.Environment.Production, "https://onlinetools.ups.com/")]
    public void ApiBaseUrl_RetrieveUrlMatchingEnvironment_WhenUpdateEnvironment(Enums.Environment mode, string validUrl) {
      UPSRestApi.Http.ClientConfiguration clientConfiguration = new("test key");
      clientConfiguration.ApiEnvironment = mode;
      Assert.That(clientConfiguration.ApiBaseUrl, Is.EqualTo(validUrl));
    }

    [Test]
    [TestCase(null)]
    [TestCase("")]
    [TestCase("Test Api")]
    public void ApiKey_RetrieveTrue_WhenMatchingInputParamter(string apiKey) {
      UPSRestApi.Http.ClientConfiguration clientConfiguration = new(apiKey);
      Assert.IsTrue(clientConfiguration.ApiKey == apiKey);
    }
  }
}
