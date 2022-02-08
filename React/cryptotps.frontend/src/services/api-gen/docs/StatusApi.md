# CryptoTpsApi.StatusApi

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**apiStatusGetBlockInfoProviderStatusGet**](StatusApi.md#apiStatusGetBlockInfoProviderStatusGet) | **GET** /api/Status/GetBlockInfoProviderStatus | 



## apiStatusGetBlockInfoProviderStatusGet

> {String: BlockInfoProviderStatusResult} apiStatusGetBlockInfoProviderStatusGet(opts)



### Example

```javascript
import CryptoTpsApi from 'crypto_tps_api';

let apiInstance = new CryptoTpsApi.StatusApi();
let opts = {
  'provider': "provider_example" // String | 
};
apiInstance.apiStatusGetBlockInfoProviderStatusGet(opts, (error, data, response) => {
  if (error) {
    console.error(error);
  } else {
    console.log('API called successfully. Returned data: ' + data);
  }
});
```

### Parameters


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **provider** | **String**|  | [optional] 

### Return type

[**{String: BlockInfoProviderStatusResult}**](BlockInfoProviderStatusResult.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

