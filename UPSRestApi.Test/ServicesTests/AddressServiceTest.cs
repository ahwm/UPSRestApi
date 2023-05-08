using UPSRestApi.Models.Common;
using UPSRestApi.Models.Dto.AddressValidation;
using UPSRestApiTestCaseSource = UPSRestApi.Test.TestCases.AddressTestCaseSource;

namespace UPSRestApi.Test.ServicesTests {
  [TestFixture]
  public class AddressServiceTest : BaseTest {
    [Test]
    [TestCaseSource(typeof(TestCases.AddressTestCaseSource), nameof(TestCases.AddressTestCaseSource.ValidateAddress_IncorrectAddressLine))]
    public void ValidateAddress_MustReturnAmbiguousAddressIndicator_WhenAddressLineInCorrect(Address address) {
      Thread.Sleep(3000);
      var result = client.AddressService.ValidateAddress(address).GetAwaiter().GetResult();
      Assert.IsInstanceOf<AddressValidationResponse>(result);
      Assert.That(result.AmbiguousAddressIndicator, Is.Not.Null);
    }

    [Test]
    [TestCaseSource(typeof(TestCases.AddressTestCaseSource), nameof(TestCases.AddressTestCaseSource.ValidateAddress_EmptryAddressLine))]
    public void ValidateAddress_MustReturnNoCandidatesIndicator_WhenAddressLineEmpty(Address address) {
      Thread.Sleep(3000);
      var result = client.AddressService.ValidateAddress(address).GetAwaiter().GetResult();
      Assert.IsInstanceOf<AddressValidationResponse>(result);
      Assert.That(result.NoCandidatesIndicator, Is.Not.Null);
    }

    [Test]
    [TestCaseSource(typeof(TestCases.AddressTestCaseSource), nameof(TestCases.AddressTestCaseSource.ValidateAddress_ValidAddressLine))]
    public void ValidateAddress_MustReturnAddressValidationResponse_WhenAddressValid(Address address) {
      Thread.Sleep(1000);
      var result = client.AddressService.ValidateAddress(address).GetAwaiter().GetResult();
      Assert.IsInstanceOf<AddressValidationResponse>(result);
    }
  }
}
