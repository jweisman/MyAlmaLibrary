using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Security.Claims;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MyLibrary
{
    public static class Utils
    {
        static string _BASEURL = "https://api-na.hosted.exlibrisgroup.com/almaws/v1";
        static string _APIKEY = "l7xxed435824541543ce8c7298d023fa810f";

        public static string AlmaApiGet(string uri)
        {
            uri = GetAlmaUri(uri);
            var http = (HttpWebRequest)WebRequest.Create(new Uri(uri));
            http.Accept = "application/json";
            var response = http.GetResponse();
            Stream resp = response.GetResponseStream();
            using (StreamReader sr = new StreamReader(resp)) { 
                return sr.ReadToEnd();
            }
        }

        public static string AlmaApiPut(string uri, string data)
        {
            uri = GetAlmaUri(uri);
            var http = (HttpWebRequest)WebRequest.Create(new Uri(uri));
            http.ContentType = "application/json";
            http.Method = "PUT";

            Stream body = http.GetRequestStream();
            ASCIIEncoding encoding = new ASCIIEncoding();
            Byte[] bytes = encoding.GetBytes(data);
            body.Write(bytes, 0, bytes.Length);
            body.Close();

            var response = http.GetResponse();
            Stream resp = response.GetResponseStream();
            string _response;
            using (StreamReader sr = new StreamReader(resp))
            { 
                _response = sr.ReadToEnd();
            }

            return _response;
        }

        public static void AlmaApiDelete(string uri)
        {
            uri = GetAlmaUri(uri);
            var http = (HttpWebRequest)WebRequest.Create(new Uri(uri));
            http.Method = "DELETE";
            var response = http.GetResponse();
        }

        private static string GetAlmaUri (string uri)
        {
            // Add a random number to ensure no caching
            Random random = new Random();
            int randomNumber = random.Next(0, 10000000);
            return String.Format("{0}{1}{2}apikey={3}&format=json&nonce={4}", _BASEURL, uri, uri.Contains("?") ? "&" : "?",
                _APIKEY, randomNumber);
        }
        
    }

    public class AuthorizeWithSessionAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Session == null || httpContext.Session["email"] == null)
                return false;

            return base.AuthorizeCore(httpContext);
        }

    }
}