﻿using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;

namespace zohobooks.parser
{
    internal class ErrorParser
    {
        internal static string getErrorMessage(HttpResponseMessage responce)
        {
            var message = "";
            var jsonObj =
                JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("message"))
                message = jsonObj["message"].ToString();
            return message;
        }
    }
}