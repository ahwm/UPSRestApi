using UPSRestApi.Models.Dto.Track;
using UPSRestApi.Test.TestCases;

namespace UPSRestApi.Test.ServicesTests {
  [TestFixture]
  public class TrackServiceTest : BaseTest {

    [Test]
    [TestCaseSource(typeof(TrackPackageTestCaseSource),nameof(TrackPackageTestCaseSource.TrackPackage_ValidData))]
    public void TrackResponse_RetrieveTrackResponse_WhenValidData(string trackingNumber) {
      Thread.Sleep(5000);
      string uuid = Guid.NewGuid().ToString();
      var result = client.TrackService.TrackPackage(uuid, "Test", trackingNumber).GetAwaiter().GetResult();
      Assert.IsInstanceOf<TrackResponse>(result);
    }
  }
}
