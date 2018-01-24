using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using zohobooks.model;
using zohobooks.parser;
using zohobooks.util;

namespace zohobooks.api
{
    /// <summary>
    ///     ContactsApi is used to<br></br>
    ///     Create a new contact to the organization,<br></br>
    ///     Get the list of contacts,<br></br>
    ///     Get or update the specified contact,<br></br>
    ///     Mark contact as active or inactive,<br></br>
    ///     Enable or disable automated payment reminders for a contact,<br></br>
    ///     Activate or deactivate the track1099,<br></br>
    ///     Send Email or statement to the contact,<br></br>
    ///     List of comments and refund history of a contact,<br></br>
    ///     Delete the contact.<br></br>
    /// </summary>
    public class ContactsApi : Api
    {
        private static readonly string baseAddress = baseurl + "/contacts";

        /// <summary>
        ///     Initializes a new instance of the <see cref="ContactsApi" /> class.
        /// </summary>
        /// <param name="auth_token">The auth_token is used for the authentication purpose.</param>
        /// <param name="organization_Id">The organization_ identifier is used to define the current working organisation.</param>
        public ContactsApi(string auth_token, string organization_Id)
            : base(auth_token, organization_Id)
        {
        }

        /// <summary>
        ///     List all contacts with pagination.
        /// </summary>
        /// <param name="parameters">
        ///     The parameters is the dictionary object which is having the filters to refine the list in the form of key,value
        ///     pairs.<br></br>The possible filter keys and variants are listed below<br></br>
        ///     <table>
        ///         <tr>
        ///             <td>contact_name</td>
        ///             <td>
        ///                 Search contacts by contact name.<br></br>Variants: <i>contact_name_startswith</i> and
        ///                 <i>contact_name_contains</i>
        ///             </td>
        ///         </tr>
        ///         <tr>
        ///             <td>company_name</td>
        ///             <td>
        ///                 Search contacts by company name.<br></br>Variants: <i>company_name_startswith</i> and
        ///                 <i>company_name_contains</i>
        ///             </td>
        ///         </tr>
        ///         <tr>
        ///             <td>first_name</td>
        ///             <td>
        ///                 Search contacts by first name of the contact person.<br></br>Variants: <i>first_name_startswith</i> and
        ///                 <i>first_name_contains</i>
        ///             </td>
        ///         </tr>
        ///         <tr>
        ///             <td>last_name</td>
        ///             <td>
        ///                 Search contacts by last name of the contact person.<br></br>Variants: <i>last_name_startswith</i> and
        ///                 <i>last_name_contains</i>
        ///             </td>
        ///         </tr>
        ///         <tr>
        ///             <td>address</td>
        ///             <td>
        ///                 Search contacts by any of the address fields.<br></br>Variants: <i>address_startswith</i> and
        ///                 <i>address_contains</i>
        ///             </td>
        ///         </tr>
        ///         <tr>
        ///             <td>email</td>
        ///             <td>
        ///                 Search contacts by email of the contact person.<br></br>Variants: <i>email_startswith</i> and
        ///                 <i>email_contains</i>
        ///             </td>
        ///         </tr>
        ///         <tr>
        ///             <td>phone</td>
        ///             <td>
        ///                 Search contacts by phone number of the contact person.<br></br>Variants: <i>phone_startswith</i> and
        ///                 <i>phone_contains</i>
        ///             </td>
        ///         </tr>
        ///         <tr>
        ///             <td>filter_by</td>
        ///             <td>
        ///                 Filter contacts by status.<br></br>Allowed Values:
        ///                 <i>Status.All, Status.Active, Status.Inactive, Status.Duplicate, Status.Customers, Status.Vendors</i>
        ///                 and <i>Status.Crm</i>
        ///             </td>
        ///         </tr>
        ///         <tr>
        ///             <td>search_text</td><td>Search contacts by contact name or notes.</td>
        ///         </tr>
        ///         <tr>
        ///             <td>sort_column</td>
        ///             <td>
        ///                 Sort contacts.<br></br>Allowed Values:
        ///                 <i>
        ///                     contact_name, first_name, last_name, email, outstanding_receivable_amount,
        ///                     outstanding_payable_amount, created_time
        ///                 </i>
        ///                 and <i>last_modified_time</i>
        ///             </td>
        ///         </tr>
        ///     </table>
        /// </param>
        /// <returns>ContactList object.</returns>
        public ContactList GetContacts(Dictionary<object, object> parameters)
        {
            var url = baseAddress;
            var responce = ZohoHttpClient.get(url, getQueryParameters(parameters));
            return ContactParser.getContactList(responce);
        }

        /// <summary>
        ///     Gets details of a specified contact.
        /// </summary>
        /// <param name="contact_id">The contact_id is the identifer of the contact for which going to get the details.</param>
        /// <returns>Contact object.</returns>
        public Contact Get(string contact_id)
        {
            var url = baseAddress + "/" + contact_id;
            var responce = ZohoHttpClient.get(url, getQueryParameters());
            Console.WriteLine(responce.Content.ReadAsStringAsync().Result);
            return ContactParser.getContact(responce);
        }

        /// <summary>
        ///     Creates a contact with given information.
        /// </summary>
        /// <param name="new_contact_info">
        ///     The new_contact_info is the Contact object which provides the information to create a
        ///     contact with contact_name as mandatory parameters.
        /// </param>
        /// <returns>Contact object.</returns>
        public Contact Create(Contact new_contact_info)
        {
            var url = baseAddress;
            var json = JsonConvert.SerializeObject(new_contact_info);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var responce = ZohoHttpClient.post(url, getQueryParameters(jsonstring));
            return ContactParser.getContact(responce);
        }

        /// <summary>
        ///     Update an existing contact. To delete a contact person remove it from the contact_persons list.
        /// </summary>
        /// <param name="contact_id">The contact_id is the identifier of the contact.</param>
        /// <param name="update_info">The update_info is the Contact object which contains the update information.</param>
        /// <returns>Contact object.</returns>
        public Contact Update(string contact_id, Contact update_info)
        {
            var url = baseAddress + "/" + contact_id;
            var json = JsonConvert.SerializeObject(update_info);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var responce = ZohoHttpClient.put(url, getQueryParameters(jsonstring));
            return ContactParser.getContact(responce);
        }

        /// <summary>
        ///     Deletes an existing contact.
        /// </summary>
        /// <param name="contact_id">The contact_id is the identifier of the contact.</param>
        /// <returns>System.String.<br></br>The success message is "The contact has been deleted."</returns>
        public string Delete(string contact_id)
        {
            var url = baseAddress + "/" + contact_id;
            var responce = ZohoHttpClient.delete(url, getQueryParameters());
            return ContactParser.getMessage(responce);
        }

        /// <summary>
        ///     Marks a contact as active.
        /// </summary>
        /// <param name="contact_id">The contact_id is the identifier of the contact.</param>
        /// <returns>System.String.<br></br>The success message is "The contact has been marked as active."</returns>
        public string MarkAsActive(string contact_id)
        {
            var url = baseAddress + "/" + contact_id + "/active";
            var responce = ZohoHttpClient.post(url, getQueryParameters());
            return ContactParser.getMessage(responce);
        }

        /// <summary>
        ///     Marks a contact as inactive.
        /// </summary>
        /// <param name="contact_id">The contact_id is the identifier of the contact.</param>
        /// <returns>System.String.<br></br>The success message is "The contact has been marked as inactive."</returns>
        public string MarkAsInactive(string contact_id)
        {
            var url = baseAddress + "/" + contact_id + "/inactive";
            var responce = ZohoHttpClient.post(url, getQueryParameters());
            return ContactParser.getMessage(responce);
        }

        /// <summary>
        ///     Enables automated payment reminders for a contact.
        /// </summary>
        /// <param name="contact_id">The contact_id is the identifier of the contact.</param>
        /// <returns>System.String.<br></br>The success message is "All reminders associated with this contact have been enabled."</returns>
        public string EnablePaymentReminder(string contact_id)
        {
            var url = baseAddress + "/" + contact_id + "/paymentreminder/enable";
            var responce = ZohoHttpClient.post(url, getQueryParameters());
            return ContactParser.getMessage(responce);
        }


        /// <summary>
        ///     Disables automated payment reminders for a contact.
        /// </summary>
        /// <param name="contact_id">The contact_id is the identifier of the contact.</param>
        /// <returns>System.String.<br></br>The success message is "All reminders associated with this contact have been stopped."</returns>
        public string DisablePaymentReminder(string contact_id)
        {
            var url = baseAddress + "/" + contact_id + "/paymentreminder/disable";
            var responce = ZohoHttpClient.post(url, getQueryParameters());
            return ContactParser.getMessage(responce);
        }

        /// <summary>
        ///     Email statement to the contact (If the Email object is not given, email will be sent with the default email
        ///     content).
        /// </summary>
        /// <param name="contact_id">The contact_id the identifier of the contact.</param>
        /// <param name="emailNotify_details">
        ///     The email notify_details is the EmailNotification object contains the email details
        ///     with to_mail_ids,subject and body parameters as mandatory.
        /// </param>
        /// <param name="attachment_paths">The attachment_paths is the file details which is going to be attached to the mail.</param>
        /// <param name="parameters">
        ///     The parameters is the dictionary object which is optionally had the following key value pairs.<br></br>
        ///     <table>
        ///         <tr>
        ///             <td>start_date</td>
        ///             <td>If start_date and end_date are not given, current month's statement will be sent to contact.</td>
        ///         </tr>
        ///         <tr>
        ///             <td>end_date</td><td>End date for the statement.</td>
        ///         </tr>
        ///     </table>
        /// </param>
        /// <returns>System.String.<br></br>The success message is "Statement has been sent to the customer." </returns>
        public string SendEmailStatement(string contact_id, EmailNotification emailNotify_details,
            string[] attachment_paths, Dictionary<object, object> parameters)
        {
            var url = baseAddress + "/" + contact_id + "/statements/email";
            var json = JsonConvert.SerializeObject(emailNotify_details);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var files = new KeyValuePair<string, string[]>("attachments", attachment_paths);
            var responce = ZohoHttpClient.post(url, getQueryParameters(), jsonstring, files);
            return ContactParser.getMessage(responce);
        }

        /// <summary>
        ///     Gets the content of the email statement.
        /// </summary>
        /// <param name="contact_id">The contact_id is the identifier of the contact.</param>
        /// <param name="parameters">
        ///     The parameters is the dictionary object which is optionally had the following key value pairs.<br></br>
        ///     <table>
        ///         <tr>
        ///             <td>start_date</td>
        ///             <td>If start_date and end_date are not given, current month's statement will be sent to contact.</td>
        ///         </tr>
        ///         <tr>
        ///             <td>end_date</td><td>End date for the statement.</td>
        ///         </tr>
        ///     </table>
        /// </param>
        /// <returns>Email object.</returns>
        public Email GetEmailStatementContent(string contact_id, Dictionary<object, object> parameters)
        {
            var url = baseAddress + "/" + contact_id + "/statements/email";
            var responce = ZohoHttpClient.get(url, getQueryParameters(parameters));
            return ContactParser.getEmailContent(responce);
        }

        /// <summary>
        ///     Sends email to contact.
        /// </summary>
        /// <param name="contact_id">The contact_id is the identifier of the contact.</param>
        /// <param name="email_content">The email_content.</param>
        /// <param name="parameters">
        ///     The parameters contains the query string in the form of key-value pair.<br></br>The possible
        ///     key as mentioned below: <br></br>br>send_customer_statement - Send customer statement pdf with email. <br></br>
        /// </param>
        /// <param name="attachment_paths">The attachment_paths are the attached files information.</param>
        /// <returns>System.String.<br></br>The success message is "Email has been sent."</returns>
        public string SendEmailContact(string contact_id, EmailNotification email_content,
            Dictionary<object, object> parameters, string[] attachment_paths)
        {
            var url = baseAddress + "/" + contact_id + "/email";
            var json = JsonConvert.SerializeObject(email_content);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var files = new KeyValuePair<string, string[]>("attachments", attachment_paths);
            var responce = ZohoHttpClient.post(url, getQueryParameters(), jsonstring, files);
            return ContactParser.getMessage(responce);
        }

        /// <summary>
        ///     List recent activities of a contact.
        /// </summary>
        /// <param name="contact_id">The contact_id is the identifier of the contact.</param>
        /// <returns>CommentList object.</returns>
        public CommentList GetComments(string contact_id)
        {
            var url = baseAddress + "/" + contact_id + "/comments";
            var responce = ZohoHttpClient.get(url, getQueryParameters());
            return ContactParser.getCommentList(responce);
        }

        /// <summary>
        ///     List the refund history of a contact.
        /// </summary>
        /// <param name="contact_id">The contact_id is the identifier of the contact.</param>
        /// <returns>CreditnoteRefundList object.</returns>
        public CreditNoteRefundList GetRefunds(string contact_id)
        {
            var url = baseAddress + "/" + contact_id + "/refunds";
            var responce = ZohoHttpClient.get(url, getQueryParameters());
            return ContactParser.getCreditNoteRefundList(responce);
        }

        /// <summary>
        ///     Track a contact for 1099 reporting. (Note: This API is only available when the organization's country is U.S.A)
        /// </summary>
        /// <param name="contact_id">The contact_id is the identifier of the contact.</param>
        /// <returns>System.String.<br></br>The success message is "1099 tracking is enabled."</returns>
        public string Track1099(string contact_id)
        {
            var url = baseAddress + "/" + contact_id + "/track1099";
            var responce = ZohoHttpClient.post(url, getQueryParameters());
            return ContactParser.getMessage(responce);
        }

        /// <summary>
        ///     Use this API to stop tracking payments to a vendor for 1099 reporting. (Note: This API is only available when the
        ///     organization's country is U.S.A)
        /// </summary>
        /// <param name="contact_id">The contact_id is the identifier of the contact.</param>
        /// <returns>System.String.<br></br>The success message is "1099 tracking is disabled."</returns>
        public string UnTrack1099(string contact_id)
        {
            var url = baseAddress + "/" + contact_id + "/untrack1099";
            var responce = ZohoHttpClient.post(url, getQueryParameters());
            return ContactParser.getMessage(responce);
        }

//--------------------------------------------------------------------------------------------
        /// <summary>
        ///     List contact persons of a contact with pagination.
        /// </summary>
        /// <param name="contact_id">The contact_id is the identifier of the contact.</param>
        /// <returns>ContactPersonList object.</returns>
        public ContactPersonList GetContactPersons(string contact_id)
        {
            var url = baseAddress + "/" + contact_id + "/contactpersons";
            var responce = ZohoHttpClient.get(url, getQueryParameters());
            return ContactParser.getContactPersonList(responce);
        }

        /// <summary>
        ///     Gets the contact person details.
        /// </summary>
        /// <param name="contact_person_id">The contact_person_id is the identifier of the contact person.</param>
        /// <returns>ContactPerson object.</returns>
        public ContactPerson GetContactPerson(string contact_id, string contact_person_id)
        {
            var url = baseAddress + "/" + contact_id + "/contactpersons/" + contact_person_id;
            var responce = ZohoHttpClient.get(url, getQueryParameters());
            Console.WriteLine(responce.Content.ReadAsStringAsync().Result);
            return ContactParser.getContactPerson(responce);
        }

        /// <summary>
        ///     Creates a contact person for contact.
        /// </summary>
        /// <param name="new_contact_person_info">
        ///     The new_contact_person_info is the ContactPerson object which is having the
        ///     information to create a contact person with contact_id as mandatory parameter.
        /// </param>
        /// <returns>ContactPerson object.</returns>
        public ContactPerson CreateContactPerson(ContactPerson new_contact_person_info)
        {
            var url = baseAddress + "/contactpersons";
            var json = JsonConvert.SerializeObject(new_contact_person_info);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var responce = ZohoHttpClient.post(url, getQueryParameters(jsonstring));
            return ContactParser.getContactPerson(responce);
        }

        /// <summary>
        ///     Update an existing contact person.
        /// </summary>
        /// <param name="contact_person_id">The contact_person_id is the identifier of the contact person.</param>
        /// <param name="update_info">
        ///     The update_info is the ContactPerson object with contact_id as mandatory parameter which
        ///     contains the changes to be modified.
        /// </param>
        /// <returns>ContactPerson object.</returns>
        public ContactPerson UpdateContactperson(string contact_person_id, ContactPerson update_info)
        {
            var url = baseAddress + "/contactpersons/" + contact_person_id;
            var json = JsonConvert.SerializeObject(update_info);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var responce = ZohoHttpClient.put(url, getQueryParameters(jsonstring));
            return ContactParser.getContactPerson(responce);
        }

        /// <summary>
        ///     Deletes an existing contact person.
        /// </summary>
        /// <param name="contact_Person_id">The contact_ person_id is the identifier of the contact person.</param>
        /// <returns>System.String.<br></br>The success message is "The contact person has been deleted."</returns>
        public string DeleteContactPerson(string contact_Person_id)
        {
            var url = baseAddress + "/contactpersons/" + contact_Person_id;
            var responce = ZohoHttpClient.delete(url, getQueryParameters());
            return ContactParser.getMessage(responce);
        }

        /// <summary>
        ///     Marks a contact person as primary for the contact.
        /// </summary>
        /// <param name="contact_person_id">The contact_person_id is the identifier of the contact person.</param>
        /// <returns>
        ///     System.String.<br></br>The success message is "This contact person has been marked as your primary contact
        ///     person."
        /// </returns>
        public string MarkAsPrimaryContactPerson(string contact_person_id)
        {
            var url = baseAddress + "/contactpersons/" + contact_person_id + "/primary";
            var responce = ZohoHttpClient.post(url, getQueryParameters());
            return ContactParser.getMessage(responce);
        }
    }
}