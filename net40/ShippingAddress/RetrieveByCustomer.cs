﻿// =====================================================================
//  THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
//  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//  PARTICULAR PURPOSE.
// =====================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Runtime.Serialization;

namespace Samples.Net40
{
    /// <summary>
    /// This sample is to demo how to retrieve all shipping addresses by customer
    /// </summary>
    public partial class ShippingAddress
    {
        /// <summary>
        /// Retrieve all shipping addresses by customer
        /// </summary>
        /// <param name="customer">Customer unique name</param>
        public void RetrieveByCustomer(string customer)
        {
            try
            {
                var url = "https://sandbox.payfabric.com/rest/v1/api/addresses" + "/" + customer;
                HttpWebRequest httpWebRequest = WebRequest.Create(url) as HttpWebRequest;
                httpWebRequest.Method = "GET";
                httpWebRequest.ContentType = "application/json; charset=utf-8";
                httpWebRequest.Headers["authorization"] = new Token().Create();
                HttpWebResponse httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse;
                Stream responseStream = httpWebResponse.GetResponseStream();
                StreamReader streamReader = new StreamReader(responseStream);
                string result = streamReader.ReadToEnd();   // JSON result
                Console.WriteLine(result);
                streamReader.Close();
                responseStream.Close();
                httpWebRequest.Abort();
                httpWebResponse.Close();

                //
                // Sample response
                // ------------------------------------------------------
                // Response text is an array of address object with json format
                // Go to https://github.com/PayFabric/APIs/wiki/API-Objects#address for more details about address object.
                // ------------------------------------------------------

            }
            catch (WebException e)
            {
                //  Handling exception from PayFabric
            }
            catch (Exception e)
            {
                //  Handling exception
            }
        }
    }
}
