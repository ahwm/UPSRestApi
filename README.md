# UPSRestApi

## Overview
UpsRestApi library for .Net used to access UPS API Catalog to browse products and view documentation.
## Features
Current version the library only support the followings feature:
1. Address Validation.
2. Dangerous Good.
   + Chemical Reference Data.
   + Acceptance Audit Pre-check.
   + Pre-Notification.
3. Tracking.

## Dependencies
This library require an external API to generate UPS bearer token[(Authorization (OAuth))](https://developer.ups.com/api/reference?apiname=OAuthAuthCode_other) before use all the service.
You can try to use the [UpsOAuthClient](https://github.com/khanhtrieu/UpsOAuthClient) to generate the token.

To install UpsOAuthClient, run:
```
Install-Package UpsOAuthClient -Version 1.0.3
```


## Installation
```
Install-Package UpsRestApi -Version 1.0.0-beta
```
See NuGet docs for additonal instructions on installing via the dialog or the console.

## Usage
A simple create validate addres example:
```
UpsOAuthClient.OAuthClient oAuthClient = new("CLIENT_ID", "CLIENT_SECRET", UpsOAuthClient.Common.Enums.ApiEnvironment.Test);
var token = Task.Run(async () => await oAuthClient.CreateToken()).GetAwaiter().GetResult();
string bearerToken = token.AccessToken;
 
UPSRestApi.UpsClient client = new UPSRestApi.UpsClient(bearerToken, UPSRestApi.Common.Enums.Environment.Test);
var addressResponse = client.AddressService.ValidateAddress(new UPSRestApi.Models.Common.Address(){
	AddressLine = "60 Manor Station Drive",
	City = "Compton",
	StateProvinceCode = "CA",
	PostalCode = "90221"
}).GetAwaiter().GetResult();
```

## Testing
The test suite in this project was specifically built to produce.

### Settings
1. Rename  ```appsettings - sample.json``` to ```appsettings.json```
2. Fill up the following configuration
	* __ClientID__: Clinet ID provided by UPS when create your application.
	* __ClientSecret__: Clinet Secret provided by UPS when create your application
	* __clientId__: Clinet ID provided by UPS when create your application.
    * __clientSecret__: Clinet Secret provided by UPS when create your application
    * __UPSAcount__: "6 characters your ups account number,
    * __ShipFromAddressLine__: The street number of your company address,
    * __ShipFromCity__: The city of your company address,
    * __ShipFromState__: The state of your company address,
    * __ShipFromZipcode__: The postal code of your company address
	
	__NOTES:__ The default country of Ship from address is the United State. If you are from another country you have to change your setting on ```UpsRestApi.Test.BaseTest.cs```
3. Change ```appsettings.json``` property __Copy to Output Directory__ to **``Copy always``** or **``Copy if newer``**
	