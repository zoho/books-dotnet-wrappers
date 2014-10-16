using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using zohobooks.model;
using zohobooks.Util;
using Newtonsoft.Json;
using zohobooks.Parser;

namespace zohobooks.api
{
    /// <summary>
    /// Class OrganizationsApi is used to<br></br>
    ///     Create a new organization,<br></br>
    ///     Get and update of the organization details,<br></br>
    ///     Get the list of organizations for the user.<br></br>
    /// </summary>
    public class OrganizationsApi:Api
    {
        static string baseAddress =baseurl + "/organizations";
        /// <summary>
        /// Initializes a new instance of the <see cref="OrganizationsApi"/> class.
        /// </summary>
        /// <param name="auth_token">The auth_token is used for the authentication purpose.</param>
        /// <param name="organization_Id">The organization_ identifier is used to define the current working organisation.</param>
        public OrganizationsApi(string auth_token, string organization_Id)
            : base(auth_token, organization_Id)
        {

        }
        /// <summary>
        /// Get the list of organizations.
        /// </summary>
        /// <returns>List of Organization objects.</returns>
        public OrganizationList GetOrganizations()
        {
            string url = baseAddress;
            var response = ZohoHttpClient.get(url, getQueryParameters());
            return OrganizationParser.getOrganizationList(response);
        }

        /// <summary>
        /// Get the details of an organization.
        /// </summary>
        /// <param name="organization_id">The organization_id is the identifier of the organization.</param>
        /// <returns>Organization object.</returns>
        public Organization Get(string organization_id)
        {
            string url = baseAddress + "/" + organization_id;
            var responce = ZohoHttpClient.get(url, getQueryParameters());
            return OrganizationParser.getOrganization(responce);
        }

        /// <summary>
        /// Create an organization.
        /// </summary>
        /// <param name="oranization_info">The oranization_info is the Organization object with name,currency_code and time_zone as mandatory attributes.</param>
        /// <returns>Organization object.</returns>
        public Organization Create(Organization oranization_info)
        {
            string url = baseAddress;
            var json = JsonConvert.SerializeObject(oranization_info);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var responce = ZohoHttpClient.post(url, getQueryParameters(jsonstring));
            return OrganizationParser.getOrganization(responce);
        }

        /// <summary>
        /// Update the details of an organization.
        /// </summary>
        /// <param name="organization_id">The organization_id is the identifier of the organization.</param>
        /// <param name="update_info">The update_info is the Organization object which contains the updation information.</param>
        /// <returns>Organization object.</returns>
        public Organization Upadte(string organization_id, Organization update_info)
        {
            string url = baseAddress + "/" + organization_id;
            var json = JsonConvert.SerializeObject(update_info);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var responce = ZohoHttpClient.put(url, getQueryParameters(jsonstring));
            return OrganizationParser.getOrganization(responce);
        }
    }
}
