using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zohobooks.model;
using zohobooks.util;
using Newtonsoft.Json;
using System.Net.Http;
using zohobooks.parser;

namespace zohobooks.api
{
    /// <summary>
    /// Class ItemsApi is used to <br></br>
    ///     Get the list of the items from the organization or details of the specified item,<br></br>
    ///     Create new item or update the item details,<br></br>
    ///     Change the status of the item as either active or inactive,<br></br>
    ///     Delete the specified item from the list of items.
    /// </summary>
    public class ItemsApi:Api
    {
        static string baseAddress = baseurl + "/items";
        /// <summary>
        /// Initializes a new instance of the <see cref="ItemsApi"/> class.
        /// </summary>
        /// <param name="auth_token">The auth_token is used for the authentication purpose.</param>
        /// <param name="organization_Id">The organization_ identifier is used to define the current working organisation.</param>
        public ItemsApi(string auth_token, string organization_Id)
            : base(auth_token, organization_Id)
        {

        }
        /// <summary>
        /// Get the list of all active items with pagination.
        /// </summary>
        /// <param name="parameters">The parameters is the Dictionary object which contains the filters in the form of key,value pair to refine the list.<br></br>The possible filters are listed below<br></br>
        /// <table>
        /// <tr><td>name</td><td>Search items by name.<br></br>Variants: <i>name_startswith</i> and <i>name_contains</i></td></tr>
        /// <tr><td>description</td><td>Search items by description.<br></br>Variants: <i>description_startswith</i> and <i>description_contains</i></td></tr>
        /// <tr><td>rate</td><td>Search items by rate.<br></br>Variants: <i>rate_less_than, rate_less_equals, rate_greater_than</i> and <i>rate_greater_equals</i></td></tr>
        /// <tr><td>tax_id</td><td>Search items by tax id.</td></tr>
        /// <tr><td>account_id</td><td>Search items by account id.</td></tr>
        /// <tr><td>filter_by</td><td>Filter items by status.<br></br>Allowed Values: <i>Status.All, Status.Active</i> and <i>Status.Inactive</i></td></tr>
        /// <tr><td>search_text</td><td>Search items by name or description.</td></tr>
        /// <tr><td>sort_column</td><td>Sort items.<br></br>Allowed Values: <i>name, rate</i> and <i>tax_name</i></td></tr>
        /// </table>
        /// </param>
        /// <returns>ItemsList object.</returns>
        public ItemList GetItems(Dictionary<object, object> parameters)
        {
            string url = baseAddress;
            var response = ZohoHttpClient.get(url, getQueryParameters(parameters));
            return ItemParser.getItemList(response);
        }
        /// <summary>
        /// Get the details of an item.
        /// </summary>
        /// <param name="item_id">The item_id is the identifier of the item.</param>
        /// <returns>LineItem object.</returns>
        public LineItem Get(string item_id)
        {
            string url = baseAddress+"/"+item_id;
            var response = ZohoHttpClient.get(url, getQueryParameters());
            return ItemParser.getItem(response);
        }
        /// <summary>
        /// Create a new item.
        /// </summary>
        /// <param name="item_info">The item_info is the LineItem object with name and rate as mandatory attributes.</param>
        /// <returns>LineItem object.</returns>
        public LineItem Create(LineItem item_info)
        {
            string url = baseAddress ;
            var json = JsonConvert.SerializeObject(item_info);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var response = ZohoHttpClient.post(url, getQueryParameters(jsonstring));
            return ItemParser.getItem(response);
        }
        /// <summary>
        /// Update the details of an item.
        /// </summary>
        /// <param name="item_id">The item_id is the identifier of the item.</param>
        /// <param name="update_info">The update_info is the LineItem object which contains the updation information.</param>
        /// <returns>LineItem object.</returns>
        public LineItem Update(string item_id,LineItem update_info)
        {
            string url = baseAddress + "/" + item_id;
            var json = JsonConvert.SerializeObject(update_info);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var response = ZohoHttpClient.put(url, getQueryParameters(jsonstring));
            return ItemParser.getItem(response);
        }
        /// <summary>
        /// Delete the item created.items that are part of transaction cannot be deleted.
        /// </summary>
        /// <param name="item_id">The item_id is the identifier of the item.</param>
        /// <returns>System.String.<br></br>The success message is "The item has been deleted." </returns>
        public string Delete(string item_id)
        {
            string url = baseAddress + "/" + item_id;;
            var response = ZohoHttpClient.delete(url, getQueryParameters());
            return ItemParser.getMessage(response);
        }
        /// <summary>
        /// Mark an inactive item as active.
        /// </summary>
        /// <param name="item_id">The item_id is the identifier of the item.</param>
        /// <returns>System.String.<br></br>The success message is "The item has been marked as active."</returns>
        public string MarkAsActive(string item_id)
        {
            string url = baseAddress + "/" + item_id+"/active";
            var response = ZohoHttpClient.post(url, getQueryParameters());
            return ItemParser.getMessage(response);
        }
        /// <summary>
        /// Mark an active item as inactive.
        /// </summary>
        /// <param name="item_id">The item_id is the identifier of the item.</param>
        /// <returns>System.String.<br></br>The success message is "The item has been marked as inactive."</returns>
        public string MarkAsInactive(string item_id)
        {
            string url = baseAddress + "/" + item_id + "/inactive";
            var response = ZohoHttpClient.post(url, getQueryParameters());
            return ItemParser.getMessage(response);
        }
    }
}
