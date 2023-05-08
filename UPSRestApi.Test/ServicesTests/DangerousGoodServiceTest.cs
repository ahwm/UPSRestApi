using DangerousGoodsModels = UPSRestApi.Models.Dto.DangerousGoods;
using TestCaseSource = UPSRestApi.Test.TestCases;

namespace UPSRestApi.Test.ServicesTests {

  [TestFixture]
  public class DangerousGoodServiceTest : BaseTest {

    #region AcceptanceAuditPreCheck
    #region Regulation 49CFR
    [Test]
    [TestCaseSource(typeof(TestCases.DangerousGoodData49CfrTestCasesSource), nameof(TestCases.DangerousGoodData49CfrTestCasesSource.AcceptanceAuditPreCheckRequests_OnePackage_ValidData))]
    public async Task AcceptanceAuditPreCheck_AcceptanceAuditPreCheckResponse_When49cfrDgValid(DangerousGoodsModels.AcceptanceAuditPreCheck.AcceptanceAuditPreCheckRequest request) {
      Thread.Sleep(5000);
      request.Shipment.ShipFromAddress = shipFromAddress;
      request.Shipment.ShipperNumber = upsAccount;

      string uuid = System.Guid.NewGuid().ToString();
      var result = client.DangerousGoodService.AcceptanceAuditPreCheck(uuid, "Test AcceptanceAuditPreCheck", request);
    }
    #endregion
    #region Regulation set ADR
    [Test]
    [TestCaseSource(typeof(TestCases.DangerousGoodAdrTestCasesSource), nameof(TestCases.DangerousGoodAdrTestCasesSource.AcceptanceAuditPreCheckRequests_OnePackage_ValidData))]
    public async Task AcceptanceAuditPreCheck_AcceptanceAuditPreCheckResponse_WhenAdrDgValid(DangerousGoodsModels.AcceptanceAuditPreCheck.AcceptanceAuditPreCheckRequest request) {
      Thread.Sleep(5000);
      AddUpsAccountAndShipFromAddress(request);

      string uuid = System.Guid.NewGuid().ToString();
      var result = client.DangerousGoodService.AcceptanceAuditPreCheck(uuid, "Test AcceptanceAuditPreCheck", request).GetAwaiter().GetResult();
      Assert.IsInstanceOf<DangerousGoodsModels.AcceptanceAuditPreCheck.AcceptanceAuditPreCheckResponse>(result);
    }
    #endregion

    #region Regulation set IATA
    [Test]
    [TestCaseSource(typeof(TestCases.DangerousGoodIataTestCasesSource),
                    nameof(TestCases.DangerousGoodIataTestCasesSource.AcceptanceAuditPreCheckRequests_OnePackage_ValidData))]
    public async Task AcceptanceAuditPreCheck_RetrieveAcceptanceAuditPreCheckResponse_WhenIataDgValid(
        DangerousGoodsModels.AcceptanceAuditPreCheck.AcceptanceAuditPreCheckRequest request) {
      Thread.Sleep(4000);
      AddUpsAccountAndShipFromAddress(request);

      string uuid = System.Guid.NewGuid().ToString();
      client.DangerousGoodService.AcceptanceAuditPreCheck(uuid, "Test AcceptanceAuditPreCheck", request);
    }

    #endregion

    #endregion

    #region ChemicalReferenceData
    [Test]
    [TestCaseSource(typeof(TestCaseSource.DangerousGoodReferenceDataTestCases), nameof(TestCaseSource.DangerousGoodReferenceDataTestCases.ChemicalReferenceDataRequests_ValidValues))]
    public async Task ReferenceData_RetrieveChemicalReferenceDataResponse_WhenDataRequestValid(
        DangerousGoodsModels.ChemicalReferenceData.ChemicalReferenceDataRequest request) {
      request.ShipperNumber = this.upsAccount;
      var result = client.DangerousGoodService.ChemicalReferenceData(request).GetAwaiter().GetResult();
      Assert.IsInstanceOf<DangerousGoodsModels.ChemicalReferenceData.ChemicalReferenceDataResponse>(result);
    }
    #endregion

    #region PreNotification
    public async Task PreNotification_ReturnPreNotificationResponse_WhenIataValid() {
    }
    #endregion

    private void AddUpsAccountAndShipFromAddress(DangerousGoodsModels.AcceptanceAuditPreCheck.AcceptanceAuditPreCheckRequest request) {
      request.Shipment.ShipFromAddress = shipFromAddress;
      request.Shipment.ShipperNumber = upsAccount;
    }
  }
}
