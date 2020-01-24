﻿using AspNetIdentity.WebClient.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AspNetIdentity.WebClient
{
    public class BaseController : Controller
    {
        private HttpClient _client;
        public HttpClient client
        {
            get
            {
                if ( _client == null)
                {
                    client = new HttpClient();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                }

                return _client;
            }

            set
            {
                _client = value;
            }
        }

        private string _bearerToken;
        internal string bearerToken
        {
            get
            {
                if (string.IsNullOrEmpty(_bearerToken))
                {
                    if(Request.Cookies["5XCUmffguLUnf5UD"] != null)
                    {
                        _bearerToken = Request.Cookies["5XCUmffguLUnf5UD"].Value;
                    }
                }

                return _bearerToken;
            }
            set
            {
                _bearerToken = value;
            }
        }

        public BaseController()
        {
            
        }

        public BTObject GetTokenObject()
        {
            // decode payload
            return this.DecodePayload(bearerToken); 
        }

        private BTObject DecodePayload(string token)
        {
            var parts = token.Split('.');
            var payload = parts[1];

            var payloadJson = Encoding.UTF8.GetString(Base64UrlDecode(payload));
            JObject jObject = JObject.Parse(payloadJson);

            return jObject.ToObject<BTObject>();
        }

        private byte[] Base64UrlDecode(string input)
        {
            var output = input;
            output = output.Replace('-', '+'); // 62nd char of encoding
            output = output.Replace('_', '/'); // 63rd char of encoding
            switch (output.Length % 4) // Pad with trailing '='s
            {
                case 0: break; // No pad chars in this case
                case 2: output += "=="; break; // Two pad chars
                case 3: output += "="; break; // One pad char
                default: throw new System.Exception("Illegal base64url string!");
            }
            var converted = Convert.FromBase64String(output); // Standard base64 decoder
            return converted;
        }

        //internal async Task<GeneralResponse> Auth(string pUsername, string pPassword)
        //{
        //    GeneralResponse response = new GeneralResponse();

        //    try
        //    {
        //        Dictionary<string, string> postMessage = new Dictionary<string, string>();
        //        postMessage.Add("grant_type", "password");
        //        postMessage.Add("username", pUsername);
        //        postMessage.Add("password", pPassword);
        //        var request = new HttpRequestMessage(HttpMethod.Post, new Uri(ConfigurationManager.AppSettings["HTTPRM_PROXY"]))
        //        {
        //            Content = new FormUrlEncodedContent(postMessage)
        //        };

        //        var httpResponse = await client.SendAsync(request);
        //        if (httpResponse.IsSuccessStatusCode)
        //        {
        //            response.Data = await httpResponse.Content.ReadAsStringAsync();
        //        }
        //        else
        //            throw new ApplicationException(httpResponse.ReasonPhrase);

        //        response.Successfully = true;
        //    }
        //    catch(Exception ex)
        //    {
        //        response.Successfully = false;
        //        response.Message = ex.Message;
        //    }

        //    return response;
        //}
    }

    public class BTObject
    {
        public string nameid { get; set; }
        public string[] roles { get; set; }
    }
}