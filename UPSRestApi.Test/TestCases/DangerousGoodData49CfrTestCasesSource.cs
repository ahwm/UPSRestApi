using static UPSRestApi.Common.Enums;
using UPSRestApi.Models.Common;
using UPSRestApi.Models.Dto.DangerousGoods.AcceptanceAuditPreCheck;

namespace UPSRestApi.Test.TestCases {
  public class DangerousGoodData49CfrTestCasesSource {
    public static IEnumerable<IAcceptanceAuditPreCheckRequest> AcceptanceAuditPreCheckRequests_OnePackage_ValidData() {
      List<AcceptanceAuditPreCheckRequest> data = new List<AcceptanceAuditPreCheckRequest>();

      string transid = System.Guid.NewGuid().ToString();
      AcceptanceAuditPreCheckRequest request = new();


      request.Shipment.ShipToAddress = new UPSRestApi.Models.Common.Address() {
        AddressLine = "9142 E. Lake Forest Ave.",
        City = "Rialto",
        StateProvinceCode = "CA",
        PostalCode = "92376",
        CountryCode = Country.US
      };

      request.Shipment.Service = new Service("001");
      request.Shipment.RegulationSet = UPSRestApi.Common.Enums.RegulationSet.FourtyNineCFR;
      request.Shipment.Packages.Add(new UPSRestApi.Models.Common.Package() {
        PackageIdentifier = "1",
        PackageWeight = new UPSRestApi.Models.Common.PackageWeight(26),
        EmergencyPhone = "562-524-9678",
        EmergencyContact = "Kamila Ramos",
        ChemicalRecords = new(){
    new UPSRestApi.Models.Common.ChemicalRecord(){
      ChemicalRecordIdentifier = "1",
      ClassDivisionNumber = "3",
      IDNumber = "UN2332",
      Quantity = 10,
      UOM=  WeightUnitOfMeasurement2.Pound,
      PackagingInstructionCode = "355",
      ProperShippingName = "Acetaldehyde oxime",
      PackagingGroupType= PackagingGroupType.III,
      PackagingType = "Fiberboard Box",
      PackagingTypeQuantity=1
    }
  }
      });
      request.Shipment.TransportationMode = UPSRestApi.Common.Enums.TransportationMode.PAX;

      data.Add(request);

      request = new();


      request.Shipment.ShipToAddress = new UPSRestApi.Models.Common.Address() {
        AddressLine = "3544 Reynolds Alley",
        City = "Los Angeles",
        StateProvinceCode = "CA",
        PostalCode = "90017",
        CountryCode = Country.US
      };

      request.Shipment.Service = new Service("001");
      request.Shipment.RegulationSet = UPSRestApi.Common.Enums.RegulationSet.FourtyNineCFR;
      request.Shipment.Packages.Add(new UPSRestApi.Models.Common.Package() {
        PackageIdentifier = "1",
        PackageWeight = new UPSRestApi.Models.Common.PackageWeight(26),
        EmergencyPhone = "562-524-9678",
        EmergencyContact = "Kamila Ramos",
        ChemicalRecords = new(){
    new UPSRestApi.Models.Common.ChemicalRecord(){
      ClassDivisionNumber = "9",
      IDNumber = "UN3480",
      Quantity = 10,
      UOM=  WeightUnitOfMeasurement2.Pound,
      PackagingInstructionCode = "355",
      ProperShippingName = "Lithium ion batteries",
      PackagingGroupType= PackagingGroupType.Blank,

      PackagingTypeQuantity=1
    }
  }
      });
      request.Shipment.TransportationMode = UPSRestApi.Common.Enums.TransportationMode.PAX;

      data.Add(request);

      return data;
    }
  }
}
