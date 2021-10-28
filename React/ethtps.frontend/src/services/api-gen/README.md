# ethtps_api

EthtpsApi - JavaScript client for ethtps_api
No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
This SDK is automatically generated by the [OpenAPI Generator](https://openapi-generator.tech) project:

- API version: 1.0
- Package version: 1.0
- Build package: org.openapitools.codegen.languages.JavascriptClientCodegen

## Installation

### For [Node.js](https://nodejs.org/)

#### npm

To publish the library as a [npm](https://www.npmjs.com/), please follow the procedure in ["Publishing npm packages"](https://docs.npmjs.com/getting-started/publishing-npm-packages).

Then install it via:

```shell
npm install ethtps_api --save
```

Finally, you need to build the module:

```shell
npm run build
```

##### Local development

To use the library locally without publishing to a remote npm registry, first install the dependencies by changing into the directory containing `package.json` (and this README). Let's call this `JAVASCRIPT_CLIENT_DIR`. Then run:

```shell
npm install
```

Next, [link](https://docs.npmjs.com/cli/link) it globally in npm with the following, also from `JAVASCRIPT_CLIENT_DIR`:

```shell
npm link
```

To use the link you just defined in your project, switch to the directory you want to use your ethtps_api from, and run:

```shell
npm link /path/to/<JAVASCRIPT_CLIENT_DIR>
```

Finally, you need to build the module:

```shell
npm run build
```

#### git

If the library is hosted at a git repository, e.g.https://github.com/GIT_USER_ID/GIT_REPO_ID
then install it via:

```shell
    npm install GIT_USER_ID/GIT_REPO_ID --save
```

### For browser

The library also works in the browser environment via npm and [browserify](http://browserify.org/). After following
the above steps with Node.js and installing browserify with `npm install -g browserify`,
perform the following (assuming *main.js* is your entry file):

```shell
browserify main.js > bundle.js
```

Then include *bundle.js* in the HTML pages.

### Webpack Configuration

Using Webpack you may encounter the following error: "Module not found: Error:
Cannot resolve module", most certainly you should disable AMD loader. Add/merge
the following section to your webpack config:

```javascript
module: {
  rules: [
    {
      parser: {
        amd: false
      }
    }
  ]
}
```

## Getting Started

Please follow the [installation](#installation) instruction and execute the following JS code:

```javascript
var EthtpsApi = require('ethtps_api');


var api = new EthtpsApi.APIApi()
var opts = {
  'provider': "provider_example", // {String} 
  'interval': "interval_example" // {String} 
};
var callback = function(error, data, response) {
  if (error) {
    console.error(error);
  } else {
    console.log('API called successfully. Returned data: ' + data);
  }
};
api.aPIGetTPSGet(opts, callback);

```

## Documentation for API Endpoints

All URIs are relative to *http://localhost*

Class | Method | HTTP request | Description
------------ | ------------- | ------------- | -------------
*EthtpsApi.APIApi* | [**aPIGetTPSGet**](docs/APIApi.md#aPIGetTPSGet) | **GET** /API/GetTPS | 
*EthtpsApi.APIApi* | [**aPIIntervalsGet**](docs/APIApi.md#aPIIntervalsGet) | **GET** /API/Intervals | 
*EthtpsApi.APIApi* | [**aPINetworksGet**](docs/APIApi.md#aPINetworksGet) | **GET** /API/Networks | 
*EthtpsApi.APIApi* | [**aPIProviderTypesGet**](docs/APIApi.md#aPIProviderTypesGet) | **GET** /API/ProviderTypes | 
*EthtpsApi.APIApi* | [**aPIProvidersGet**](docs/APIApi.md#aPIProvidersGet) | **GET** /API/Providers | 
*EthtpsApi.APIV2Api* | [**aPIV2HomePageModelGet**](docs/APIV2Api.md#aPIV2HomePageModelGet) | **GET** /API/v2/HomePageModel | 
*EthtpsApi.APIV2Api* | [**aPIV2InstantTPSGet**](docs/APIV2Api.md#aPIV2InstantTPSGet) | **GET** /API/v2/InstantTPS | 
*EthtpsApi.APIV2Api* | [**aPIV2IntervalsGet**](docs/APIV2Api.md#aPIV2IntervalsGet) | **GET** /API/v2/Intervals | 
*EthtpsApi.APIV2Api* | [**aPIV2MaxTPSGet**](docs/APIV2Api.md#aPIV2MaxTPSGet) | **GET** /API/v2/MaxTPS | 
*EthtpsApi.APIV2Api* | [**aPIV2NetworksGet**](docs/APIV2Api.md#aPIV2NetworksGet) | **GET** /API/v2/Networks | 
*EthtpsApi.APIV2Api* | [**aPIV2ProviderTypesGet**](docs/APIV2Api.md#aPIV2ProviderTypesGet) | **GET** /API/v2/ProviderTypes | 
*EthtpsApi.APIV2Api* | [**aPIV2ProvidersGet**](docs/APIV2Api.md#aPIV2ProvidersGet) | **GET** /API/v2/Providers | 
*EthtpsApi.APIV2Api* | [**aPIV2RecalculateMaxTPSGet**](docs/APIV2Api.md#aPIV2RecalculateMaxTPSGet) | **GET** /API/v2/RecalculateMaxTPS | 
*EthtpsApi.APIV2Api* | [**aPIV2TPSGet**](docs/APIV2Api.md#aPIV2TPSGet) | **GET** /API/v2/TPS | 


## Documentation for Models

 - [EthtpsApi.HomePageViewModel](docs/HomePageViewModel.md)
 - [EthtpsApi.Network](docs/Network.md)
 - [EthtpsApi.Provider](docs/Provider.md)
 - [EthtpsApi.ProviderInfo](docs/ProviderInfo.md)
 - [EthtpsApi.ProviderResponseModel](docs/ProviderResponseModel.md)
 - [EthtpsApi.ProviderType](docs/ProviderType.md)
 - [EthtpsApi.TPSDataPoint](docs/TPSDataPoint.md)
 - [EthtpsApi.TPSResponseModel](docs/TPSResponseModel.md)


## Documentation for Authorization

All endpoints do not require authorization.