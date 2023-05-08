using System.Configuration;
using UPSRestApi.Models.Common;
using UPSRestApi.Models.Dto;
using UPSRestApi.Models.Dto.DangerousGoods.AcceptanceAuditPreCheck;
using UPSRestApi.Models.Dto.DangerousGoods.PreNotification;
using static UPSRestApi.Common.Enums;
using CommonEnums = UPSRestApi.Common.Enums;

namespace UPSRestApi.Test.TestCases {
  public class DangerousGoodIataTestCasesSource {
    public const CommonEnums.RegulationSet DefaultRegularSet = CommonEnums.RegulationSet.IATA;
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
      request.Shipment.RegulationSet = UPSRestApi.Common.Enums.RegulationSet.IATA;
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

    public static IEnumerable<IAcceptanceAuditPreCheckRequest> AcceptanceAuditPreCheckRequests_OnePackage_InValidData() {
      List<AcceptanceAuditPreCheckRequest> data = new List<AcceptanceAuditPreCheckRequest>();

      string transid = System.Guid.NewGuid().ToString();
      AcceptanceAuditPreCheckRequest request = new();
      //request.Shipment.ShipperNumber = ConfigurationManager.AppSettings["IDNumber"].ToString();

      request.Shipment.ShipToAddress = new UPSRestApi.Models.Common.Address() {
        AddressLine = "9678 Mayflower Street",
        City = "Baldwin Park",
        StateProvinceCode = "CA",
        PostalCode = "91706",
        CountryCode = Country.US
      };
      request.Shipment.Service = new Service("001");
      request.Shipment.RegulationSet = UPSRestApi.Common.Enums.RegulationSet.IATA;
      request.Shipment.Packages.Add(new UPSRestApi.Models.Common.Package() {
        PackageIdentifier = "1",
        PackageWeight = new UPSRestApi.Models.Common.PackageWeight(26),
        EmergencyPhone = "310-596-3742",
        EmergencyContact = "Nicholas Myers",
        ChemicalRecords = new(){
    new UPSRestApi.Models.Common.ChemicalRecord(){
      ChemicalRecordIdentifier = "1",
      ClassDivisionNumber = "3",
      IDNumber = "UN2332",
      Quantity = 10,
      UOM= WeightUnitOfMeasurement2.Pound,
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

      return data;
    }

    public static IEnumerable<IAcceptanceAuditPreCheckRequest> AcceptanceAuditPreCheckRequests_MultiplePackage_ValidData() {
      List<AcceptanceAuditPreCheckRequest> requests = new List<AcceptanceAuditPreCheckRequest>();
      Address shipfromAddress = new() {
        CountryCode = CommonEnums.Country.US
      };
      requests.Add(new AcceptanceAuditPreCheckRequest() {
        Shipment = new UPSRestApi.Models.Common.Shipment() {
          RegulationSet = DefaultRegularSet,
          Service = new Service("001"),
          Packages = new List<Package>() {
            new Package() {
             PackageWeight = new PackageWeight() {
            Weight=26
             },
             TransportationMode = CommonEnums.TransportationMode.PAX,
             EmergencyPhone="310-596-3742",
             EmergencyContact="Shipping Department",
             ChemicalRecords = new List<ChemicalRecord>(){
             new ChemicalRecord(){
               ClassDivisionNumber = "3",
              
               Quantity = 10,
               UOM = WeightUnitOfMeasurement2.Pound,
               PackagingInstructionCode="355",
               ProperShippingName = "Acetaldehyde oxime",
               PackagingType = "Fiberboard Box",
               PackagingGroupType = CommonEnums.PackagingGroupType.III,
               PackagingTypeQuantity = 1,
               CommodityRegulatedLevelCode = CommonEnums.CommodityRegulatedLevelCode.FR
             }
             }
            }
          }
        }
      });


      return requests;
    }


    public static IEnumerable<PreNotificationRequest> PreNotificationRequests_ValidData() {
      List<PreNotificationRequest> requests = new List<PreNotificationRequest>();
      UPSRestApi.Models.Dto.DangerousGoods.PreNotification.PreNotificationRequest request = new();
      request.Request.TransactionRef.TransactionIdentifier = "test identifier";
      var shipment = request.Shipment;

      shipment.ShipmentIdentificationNumber = "1Z2398YY81288";

      shipment.ShipToAddress = new Address() {
        AddressLine = "464 E. White Dr.",
        City = "Huntington Beach",
        StateProvinceCode = "CA",
        PostalCode = "92647",
        CountryCode = Country.US
      };
      shipment.PickupDate = DateTime.Now.ToString("yyyyMMdd");
      shipment.Service = new Service("GND");
      shipment.RegulationSet = RegulationSet.IATA;
      shipment.Packages.Add(new Package() {
        TrackingNumber = "1Z33445567001",
        PackageWeight = new PackageWeight() { Weight = 12 },
        TransportationMode = TransportationMode.GND,
        VoidIndicator = "",
        PackagePoints = "12",
        ChemicalRecords = new List<ChemicalRecord>() {
    { new ChemicalRecord(){
     ReportableQuantity = "1",
     ClassDivisionNumber= "I",
     SubRiskClass = "1234",
     IDNumber="UN2716",
     PackagingGroupType =  PackagingGroupType.Blank,
     Quantity = 1,
     UOM = WeightUnitOfMeasurement2.Pound,
     PackagingInstructionCode = "TEST",
     EmergencyContact = "",
     EmergencyPhone = "",
     ProperShippingName = "TEST SHIPPING",
     TechnicalName = "",
     AdditionalDescription = "",
     PackagingType = "",
     HazardLabelRequired = "label",
     PackagingTypeQuantity = 1,
     CommodityRegulatedLevelCode = CommodityRegulatedLevelCode.LR,
     TransportCategory = "0",
     TunnelRestrictionCode = "1",
    QValue = QValue.ZeroPointOne,
    OverPackedIndicator= "0",
    AllPackedInOneIndicator=""
    } }
  }
      });
      //===============
      request = new();
      request.Request.TransactionRef.TransactionIdentifier = "test identifier";
       shipment = request.Shipment;

      shipment.ShipmentIdentificationNumber = "1Z2398YY81288";

      shipment.ShipToAddress = new Address() {
        AddressLine = "464 E. White Dr.",
        City = "Huntington Beach",
        StateProvinceCode = "CA",
        PostalCode = "92647",
        CountryCode = Country.US
      };
      shipment.PickupDate = DateTime.Now.ToString("yyyyMMdd");
      shipment.Service = new Service("GND");
      shipment.RegulationSet = RegulationSet.IATA;
      shipment.Packages.Add(new Package() {
        TrackingNumber = "1Z33445567001",
        PackageWeight = new PackageWeight() { Weight = 12 },
        TransportationMode = TransportationMode.GND,
        VoidIndicator = "",
        PackagePoints = "12",
        ChemicalRecords = new List<ChemicalRecord>() {
    { new ChemicalRecord(){
     ReportableQuantity = "1",
     ClassDivisionNumber= "9",
     
     IDNumber="UN3480",
     PackagingGroupType =  PackagingGroupType.Blank,
     Quantity = 1,
     UOM = WeightUnitOfMeasurement2.Pound,
     PackagingInstructionCode = "TEST",
     EmergencyContact = "",
     EmergencyPhone = "",
     ProperShippingName = "Lithium ion batteries",
     TechnicalName = "",
     AdditionalDescription = "",
     PackagingType = "",
     HazardLabelRequired = "label",
     PackagingTypeQuantity = 1,
     CommodityRegulatedLevelCode = CommodityRegulatedLevelCode.LR,
     TransportCategory = "0",
     TunnelRestrictionCode = "1",
    QValue = QValue.ZeroPointOne,
    OverPackedIndicator= "0",
    AllPackedInOneIndicator=""
    } }
  }
      });

      return requests;
    }

    public static IEnumerable<PreNotificationRequest> PreNotificationRequests_InValidData() {
      List<PreNotificationRequest> requests = new List<PreNotificationRequest>();
      Address shipfromAddress = new() {
        CountryCode = CommonEnums.Country.US
      };
      requests.Add(new PreNotificationRequest() {
        Shipment = new UPSRestApi.Models.Common.Shipment() {
          RegulationSet = DefaultRegularSet,
          Service = new Service("001"),
          Packages = new List<Package>() {
            new Package() {
             PackageWeight = new PackageWeight() {
            Weight=26
             },
             TransportationMode = CommonEnums.TransportationMode.PAX,
             EmergencyPhone="424-327-2954",
             EmergencyContact="Shipping Department",
             ChemicalRecords = new List<ChemicalRecord>(){
             new ChemicalRecord(){
               ClassDivisionNumber = "3",
               IDNumber = ConfigurationManager.AppSettings["IDNumber"].ToString(),
               Quantity = 10,
               UOM = WeightUnitOfMeasurement2.Pound,
               PackagingInstructionCode="355",
               ProperShippingName = "Acetaldehyde oxime",
               PackagingType = "Fiberboard Box",
               PackagingGroupType = CommonEnums.PackagingGroupType.III,
               PackagingTypeQuantity = 1,
               CommodityRegulatedLevelCode = CommonEnums.CommodityRegulatedLevelCode.FR
             }
             }
            }
          }
        }
      });


      return requests;
    }
  }
}
