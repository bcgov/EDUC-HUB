using Microsoft.AspNetCore.Authentication.Twitter;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CASInterfaceService.Pages.Models
{
    public class CASAPTransactionRegistration
    {
        List<CASAPTransaction> casAPTransactionList;
        static CASAPTransactionRegistration casregd = null;

        // TEST  - molson.cas.gov.bc.ca - 142.34.166.75  - 7015
        // TRAIN - molson.cas.gov.bc.ca - 142.34.166.75  - 7013
        // PROD  - labatt.cas.gov.bc.ca - 142.34.166.201 - 7010

        //private const string URL = "https://<server>:<port>ords/cas/cfs/apinvoice/";
        //private const string URL = "https://molson.cas.gov.bc.ca:7015/ords/cas/cfs/apinvoice/";
        private const string URL = "https://wsgw.test.jag.gov.bc.ca/victim/ords/cas/cfs/apinvoice/";
        //private const string TokenURL = "https://<server>:<port>/ords/casords/oauth/token";
        //private const string TokenURL = "https://molson.cas.gov.bc.ca:7015/ords/casords/oauth/token";
        private const string TokenURL = "https://wsgw.test.jag.gov.bc.ca/victim/ords/cas/oauth/token";

        private CASAPTransactionRegistration()
        {
            casAPTransactionList = new List<CASAPTransaction>();
        }

        public static CASAPTransactionRegistration getInstance()
        {
            if (casregd == null)
            {
                casregd = new CASAPTransactionRegistration();
                return casregd;
            }
            else
            {
                return casregd;
            }
        }

        public void Add(CASAPTransaction casapTransaction)
        {
            casAPTransactionList.Add(casapTransaction);
        }

        public List<CASAPTransaction> getAllCASAPTransaction()
        {
            return casAPTransactionList;
        }

        public List<CASAPTransaction> getUpdateCASAPTransaction()
        {
            return casAPTransactionList;
        }

        public async void getTransactionsFromCAS()//CASAPTransaction casapTransaction)
        {
            try
            {
                HttpClientHandler handler = new HttpClientHandler();

                Console.WriteLine("GET: + " + TokenURL);

                HttpClient client = new HttpClient(handler);

                var byteArray = Encoding.ASCII.GetBytes("Y3lia0NKOFBvYm1FdnIzcmtwbmtlQS4uOmYwTTR6bTJaaS1KSFdYdVQ2c3dnY2cuLg==");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

                HttpResponseMessage response = await client.GetAsync(TokenURL);
                HttpContent content = response.Content;

                Console.WriteLine("Response StatusCode: " + (int)response.StatusCode);

                // ... Read the string.
                string result = await content.ReadAsStringAsync();

                // ... Display the result.
                if (result != null && result.Length >= 50)
                {
                    Console.WriteLine(result.Substring(0, 50) + "...");
                }
            }
            catch (Exception e)
            {
                var errorContent = new StringContent("Didn't work", Encoding.UTF8, "application/json");
                Console.WriteLine("Error in getTransactionsFromCAS. ");// + client.BaseAddress.ToString() + errorContent + client + e.ToString());
                throw e;
            }
        }
    }
}
