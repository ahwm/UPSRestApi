using UPSRestApi.Models.Common;

namespace UPSRestApi.Test.TestCases {
  public class AddressTestCaseSource {
    public static IEnumerable<Address?> ValidateAddress_ValidAddressLine() {
      List<Address?> addresses = new List<Address?>();
      addresses.Add(new Address() {
        AddressLine = "60 Manor Station Drive",
        City = "Compton",
        StateProvinceCode = "CA",
        PostalCode = "90221"
      });

      addresses.Add(new Address() {
        AddressLine = "8739 East Lake Forest Lane",
        City = "Huntington Beach",
        StateProvinceCode = "CA",
        PostalCode = "92647"
      });

      addresses.Add(new Address() {
        AddressLine = "9249 Carson St.",
        City = "Hanford",
        StateProvinceCode = "CA",
        PostalCode = "93230"
      });

      addresses.Add(new Address() {
        AddressLine = "16424 Seine",
        City = "Artersia",
        StateProvinceCode = "CA",
        PostalCode = "90701"
      });

      return addresses;
    }
    public static IEnumerable<Address?> ValidateAddress_EmptryAddressLine() {
      List<Address?> addresses = new List<Address?>();
      
      addresses.Add(new Address() { 
        PostalCode = "90701",
        StateProvinceCode = "CA"
      });

      return addresses;
    }

    public static IEnumerable<Address?> ValidateAddress_IncorrectAddressLine() {
      List<Address?> addresses = new List<Address?>();
      addresses.Add(new Address() {
        AddressLine = "565 East 6th Street",
        City = "",
        StateProvinceCode = "CA",
        PostalCode = "95122"
      });

     

      return addresses;
    }
  }
}
