using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBuydBest.Models
{
    public class Amazweb
    {
        public class MWS
        {
            [System.Runtime.InteropServices.ComVisible(true)]
            public interface Ivba
            {
                String ListMatchingProducts(
                    String accessKeyId,
                    String secretAccessKey,
                    String merchantId,
                    String marketplaceId,
                    String query,
                    String queryContextId
                );
            }

            [System.Runtime.InteropServices.ComVisible(true)]
            [System.Runtime.InteropServices.ClassInterface(System.Runtime.InteropServices.ClassInterfaceType.None)]
            public class vba : Ivba
            {
                private const String SERVICE_URL = "https://mws.amazonservices.jp/Products/2011-10-01";
                private const String APP_NAME = "dummy";
                private const String APP_VERSION = "1";

                public String ListMatchingProducts(
                    String accessKeyId,
                    String secretAccessKey,
                    String merchantId,
                    String marketplaceId,
                    String query,
                    String queryContextId
                )
                {
                    MarketplaceWebServiceProductsConfig config = new MarketplaceWebServiceProductsConfig();
                    config.ServiceURL = SERVICE_URL;

                    MarketplaceWebServiceProductsClient service = new MarketplaceWebServiceProductsClient(
                        APP_NAME, APP_VERSION, accessKeyId, secretAccessKey, config);

                    ListMatchingProductsRequest request = new ListMatchingProductsRequest();
                    request.SellerId = merchantId;
                    request.MarketplaceId = marketplaceId;
                    request.Query = query;
                    request.QueryContextId = queryContextId;

                    try
                    {
                        ListMatchingProductsResponse response = service.ListMatchingProducts(request);
                        return service.ResponseBody;
                    }
                    catch (MarketplaceWebServiceProductsException ex)
                    {
                        Console.WriteLine("Caught Exception: " + ex.Message);
                        Console.WriteLine("Response Status Code: " + ex.StatusCode);
                        Console.WriteLine("Error Code: " + ex.ErrorCode);
                        Console.WriteLine("Error Type: " + ex.ErrorType);
                        Console.WriteLine("Request ID: " + ex.RequestId);
                        Console.WriteLine("XML: " + ex.XML);
                    }

                    return null;
                }
            }
        }
    }
}