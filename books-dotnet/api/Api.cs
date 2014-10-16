using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace zohobooks.api
{
    /// <summary>
    /// Class Api is the super class to all API classes.
    /// This class will maintains the service URL and credentials.
    /// </summary>
    public class Api
    {
        /// <summary>
        /// It is the API base URL for the Zoho Books service. 
        /// </summary>
        public static string baseurl = "https://books.zoho.com/api/v3";
        /// <summary>
        /// Initializes static members of the <see cref="Api"/> class.
        /// </summary>
        static Api()
        {
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Ignore
            };
        }
        /// <summary>
        /// The authtoken is the authentication parameter which authenticates the API call.
        /// </summary>
        protected string authtoken;
        /// <summary>
        /// The organization identifier is used to choose on which organisation,the API call has been applied.
        /// </summary>
        protected string organizationId;
        /// <summary>
        /// Initializes a new instance of the <see cref="Api"/> class.
        /// </summary>
        /// <param name="auth_token">User's authToken.</param>
        /// <param name="organization_id">The organization_id is the identifier of the organisation on which user is working currently.</param>
        public Api(String auth_token, String organization_id)
        {
            authtoken = auth_token;
            organizationId = organization_id;
        }
        /// <summary>
        /// Constructs the QueryString using users authToken and organisation id.
        /// </summary>
        /// <returns>A queryString as a Dictionary object.</returns>
        public Dictionary<object,object> getQueryParameters()
        {
            var queryParameters = new Dictionary<object, object>();
            queryParameters.Add("authtoken", authtoken);
            queryParameters.Add("organization_id", organizationId);
            return queryParameters;
        }
        /// <summary>
        /// Constructs the Dictionary object using user's auth token,organisation id and using the query parameters.
        /// </summary>
        /// <param name="queryParameters">The query parameters.</param>
        /// <returns>Dictionary{System.ObjectSystem.Object}.</returns>
        public Dictionary<object,object> getQueryParameters(Dictionary<object,object> queryParameters)
        {
            if (queryParameters == null)
                queryParameters = new Dictionary<object, object>();
            queryParameters.Add("authtoken", authtoken);
            queryParameters.Add("organization_id", organizationId);
            return queryParameters;
        }
    }
}
