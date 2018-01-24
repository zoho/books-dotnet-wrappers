using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using zohobooks.model;

namespace zohobooks.parser
{
    /// <summary>
    ///     Used to define the parser object of OrganizationsApi.
    /// </summary>
    internal class OrganizationParser
    {
        /// <summary>
        ///     Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        public int code { get; set; }

        /// <summary>
        ///     Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        public string message { get; set; }

        /// <summary>
        ///     Gets or sets the organizations.
        /// </summary>
        /// <value>The organizations.</value>
        public List<Organization> organizations { get; set; }

        /// <summary>
        ///     Gets or sets the organization.
        /// </summary>
        /// <value>The organization.</value>
        public Organization organization { get; set; }

        internal static OrganizationList getOrganizationList(HttpResponseMessage response)
        {
            var organizationList = new OrganizationList();
            var jsonObj =
                JsonConvert.DeserializeObject<Dictionary<string, object>>(response.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("organizations"))
            {
                var organizationArray =
                    JsonConvert.DeserializeObject<List<object>>(jsonObj["organizations"].ToString());
                foreach (var organizationObj in organizationArray)
                {
                    var organization = new Organization();
                    organization = JsonConvert.DeserializeObject<Organization>(organizationObj.ToString());
                    organizationList.Add(organization);
                }
            }
            return organizationList;
        }

        internal static Organization getOrganization(HttpResponseMessage responce)
        {
            var organization = new Organization();
            var jsonObj =
                JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("organization"))
                organization = JsonConvert.DeserializeObject<Organization>(jsonObj["organization"].ToString());
            return organization;
        }

        internal static Address getOrganizationAddress(HttpResponseMessage responce)
        {
            var address = new Address();
            var jsonObj =
                JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("organization_address"))
                address = JsonConvert.DeserializeObject<Address>(jsonObj["organization_address"].ToString());
            return address;
        }
    }
}