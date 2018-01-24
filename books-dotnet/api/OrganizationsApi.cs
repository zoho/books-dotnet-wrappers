using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using zohobooks.model;
using zohobooks.parser;
using zohobooks.util;

namespace zohobooks.api
{
    /// <summary>
    ///     Class OrganizationsApi is used to<br></br>
    ///     Create a new organization,<br></br>
    ///     Get and update of the organization details,<br></br>
    ///     Get the list of organizations for the user.<br></br>
    /// </summary>
    public class OrganizationsApi : Api
    {
        /// <summary>
        ///     The base address
        /// </summary>
        private static readonly string baseAddress = baseurl + "/organizations";

        /// <summary>
        ///     Initializes a new instance of the <see cref="OrganizationsApi" /> class.
        /// </summary>
        /// <param name="auth_token">The auth_token is used for the authentication purpose.</param>
        /// <param name="organization_Id">The organization_ identifier is used to define the current working organisation.</param>
        public OrganizationsApi(string auth_token, string organization_Id)
            : base(auth_token, organization_Id)
        {
        }

        /// <summary>
        ///     Get the list of organizations.
        /// </summary>
        /// <returns>List of Organization objects.</returns>
        public OrganizationList GetOrganizations()
        {
            var url = baseAddress;
            var response = ZohoHttpClient.get(url, getQueryParameters());
            return OrganizationParser.getOrganizationList(response);
        }

        /// <summary>
        ///     Get the details of an organization.
        /// </summary>
        /// <param name="organization_id">The organization_id is the identifier of the organization.</param>
        /// <returns>Organization object.</returns>
        public Organization Get(string organization_id)
        {
            var url = baseAddress + "/" + organization_id;
            var responce = ZohoHttpClient.get(url, getQueryParameters());
            return OrganizationParser.getOrganization(responce);
        }

        /// <summary>
        ///     Create an organization.
        /// </summary>
        /// <param name="oranization_info">
        ///     The oranization_info is the Organization object with name,currency_code and time_zone as
        ///     mandatory attributes.
        /// </param>
        /// <returns>Organization object.</returns>
        public Organization Create(Organization oranization_info)
        {
            var url = baseAddress;
            var json = JsonConvert.SerializeObject(oranization_info);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var responce = ZohoHttpClient.post(url, getQueryParameters(jsonstring));
            Console.WriteLine(responce.Content.ReadAsStringAsync().Result);
            return OrganizationParser.getOrganization(responce);
        }

        /// <summary>
        ///     Update the details of an organization.
        /// </summary>
        /// <param name="organization_id">The organization_id is the identifier of the organization.</param>
        /// <param name="update_info">The update_info is the Organization object which contains the updation information.</param>
        /// <returns>Organization object.</returns>
        public Organization Upadte(string organization_id, Organization update_info)
        {
            var url = baseAddress + "/" + organization_id;
            var json = JsonConvert.SerializeObject(update_info);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var responce = ZohoHttpClient.put(url, getQueryParameters(jsonstring));
            return OrganizationParser.getOrganization(responce);
        }

        /// <summary>
        ///     Adds the organization address.
        /// </summary>
        /// <param name="address_info">The address_info.</param>
        /// <returns>Address.</returns>
        public Address AddOrganizationAddress(Address address_info)
        {
            var url = baseAddress + "/address";
            var json = JsonConvert.SerializeObject(address_info);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var responce = ZohoHttpClient.post(url, getQueryParameters(jsonstring));
            return OrganizationParser.getOrganizationAddress(responce);
        }

        /// <summary>
        ///     Updates the organization address.
        /// </summary>
        /// <param name="organization_address_id">The organization_address_id.</param>
        /// <param name="update_info">The update_info.</param>
        /// <returns>Address.</returns>
        public Address UpdateOrganizationAddress(string organization_address_id, Address update_info)
        {
            var url = baseAddress + "/address/" + organization_address_id;
            var json = JsonConvert.SerializeObject(update_info);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var responce = ZohoHttpClient.put(url, getQueryParameters(jsonstring));
            return OrganizationParser.getOrganizationAddress(responce);
        }
    }
}