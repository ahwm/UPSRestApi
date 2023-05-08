using UPSRestApi.Models.Dto.DangerousGoods.ChemicalReferenceData;

namespace UPSRestApi.Test.TestCases {
  public class DangerousGoodReferenceDataTestCases {
    public static IEnumerable<ChemicalReferenceDataRequest?> ChemicalReferenceDataRequests_ValidValues() {
      List<ChemicalReferenceDataRequest> data = new();
      data.Add(new ChemicalReferenceDataRequest() {
        IDNumber = "UN3480",
        ProperShippingName = "Lithium ion batteries"
      });

      //data.Add(new ChemicalReferenceDataRequest() {
      //  IDNumber = "UN3516",
      //  ProperShippingName = "Adsorbed gas, toxic, corrosive, n.o.s."
      //});
      
      //data.Add(new ChemicalReferenceDataRequest() {
      //  IDNumber = "UN3065",
      //  ProperShippingName = "Alcoholic beverages "
      //});

      return data;

    }
  }
}
