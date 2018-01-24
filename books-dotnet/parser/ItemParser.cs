using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using zohobooks.model;

namespace zohobooks.parser
{
    /// <summary>
    ///     Used to define the parser object of ItemsApi.
    /// </summary>
    internal class ItemParser
    {
        internal static string getMessage(HttpResponseMessage responce)
        {
            var message = "";
            var jsonObj =
                JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("message"))
                message = jsonObj["message"].ToString();
            return message;
        }

        internal static ItemList getItemList(HttpResponseMessage response)
        {
            var itemList = new ItemList();
            var jsonObj =
                JsonConvert.DeserializeObject<Dictionary<string, object>>(response.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("items"))
            {
                var itemsArray = JsonConvert.DeserializeObject<List<object>>(jsonObj["items"].ToString());
                foreach (var itemObj in itemsArray)
                {
                    var item = new LineItem();
                    item = JsonConvert.DeserializeObject<LineItem>(itemObj.ToString());
                    itemList.Add(item);
                }
            }
            if (jsonObj.ContainsKey("page_context"))
            {
                var pageContext = new PageContext();
                pageContext = JsonConvert.DeserializeObject<PageContext>(jsonObj["page_context"].ToString());
                itemList.page_context = pageContext;
            }
            return itemList;
        }

        internal static LineItem getItem(HttpResponseMessage response)
        {
            var item = new LineItem();
            var jsonObj =
                JsonConvert.DeserializeObject<Dictionary<string, object>>(response.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("item"))
                item = JsonConvert.DeserializeObject<LineItem>(jsonObj["item"].ToString());
            return item;
        }
    }
}