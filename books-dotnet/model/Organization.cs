using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zohobooks.model
{
    /// <summary>
    /// Class Organization.
    /// </summary>
    public class Organization
    {
        /// <summary>
        /// Gets or sets the organization_id.
        /// </summary>
        /// <value>The organization_id.</value>
        public string organization_id { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string name { get; set; }
        /// <summary>
        /// Gets or sets the contact_name.
        /// </summary>
        /// <value>The contact_name.</value>
        public string contact_name { get; set; }
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        public string email { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Organization"/> is is_default_org.
        /// </summary>
        /// <value><c>true</c> if is_default_org; otherwise, <c>false</c>.</value>
        public bool is_default_org { get; set; }
        /// <summary>
        /// Gets or sets the plan_type.
        /// </summary>
        /// <value>The plan_type.</value>
        public int plan_type { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Organization"/> is tax_group_enabled.
        /// </summary>
        /// <value><c>true</c> if tax_group_enabled; otherwise, <c>false</c>.</value>
        public bool tax_group_enabled { get; set; }
        /// <summary>
        /// Gets or sets the plan_name.
        /// </summary>
        /// <value>The plan_name.</value>
        public string plan_name { get; set; }
        /// <summary>
        /// Gets or sets the plan_period.
        /// </summary>
        /// <value>The plan_period.</value>
        public string plan_period { get; set; }
        /// <summary>
        /// Gets or sets the language_code.
        /// </summary>
        /// <value>The language_code.</value>
        public string language_code { get; set; }
        /// <summary>
        /// Gets or sets the fiscal_year_start_month.
        /// </summary>
        /// <value>The fiscal_year_start_month.</value>
        public string fiscal_year_start_month { get; set; }
        /// <summary>
        /// Gets or sets the account_created_date.
        /// </summary>
        /// <value>The account_created_date.</value>
        public string account_created_date { get; set; }
        /// <summary>
        /// Gets or sets the account_created_date_formatted.
        /// </summary>
        /// <value>The account_created_date_formatted.</value>
        public string account_created_date_formatted { get; set; }
        /// <summary>
        /// Gets or sets the time_zone.
        /// </summary>
        /// <value>The time_zone.</value>
        public string time_zone { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Organization"/> is is_org_active.
        /// </summary>
        /// <value><c>true</c> if is_org_active; otherwise, <c>false</c>.</value>
        public bool is_org_active { get; set; }
        /// <summary>
        /// Gets or sets the currency_id.
        /// </summary>
        /// <value>The currency_id.</value>
        public string currency_id { get; set; }
        /// <summary>
        /// Gets or sets the currency_code.
        /// </summary>
        /// <value>The currency_code.</value>
        public string currency_code { get; set; }
        /// <summary>
        /// Gets or sets the currency_symbol.
        /// </summary>
        /// <value>The currency_symbol.</value>
        public string currency_symbol { get; set; }
        /// <summary>
        /// Gets or sets the currency_format.
        /// </summary>
        /// <value>The currency_format.</value>
        public string currency_format { get; set; }
        /// <summary>
        /// Gets or sets the price_precision.
        /// </summary>
        /// <value>The price_precision.</value>
        public int price_precision { get; set; }
        /// <summary>
        /// Gets or sets the date_format.
        /// </summary>
        /// <value>The date_format.</value>
        public string date_format { get; set; }
        /// <summary>
        /// Gets or sets the field_separator.
        /// </summary>
        /// <value>The field_separator.</value>
        public string field_separator { get; set; }
        /// <summary>
        /// Gets or sets the industry_type.
        /// </summary>
        /// <value>The industry_type.</value>
        public string industry_type { get; set; }
        /// <summary>
        /// Gets or sets the industry_size.
        /// </summary>
        /// <value>The industry_size.</value>
        public string industry_size { get; set; }
        /// <summary>
        /// Gets or sets the company_id_label.
        /// </summary>
        /// <value>The company_id_label.</value>
        public string company_id_label { get; set; }
        /// <summary>
        /// Gets or sets the company_id_value.
        /// </summary>
        /// <value>The company_id_value.</value>
        public string company_id_value { get; set; }
        /// <summary>
        /// Gets or sets the tax_id_label.
        /// </summary>
        /// <value>The tax_id_label.</value>
        public string tax_id_label { get; set; }
        /// <summary>
        /// Gets or sets the tax_id_value.
        /// </summary>
        /// <value>The tax_id_value.</value>
        public string tax_id_value { get; set; }
        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>The address.</value>
        public Address address { get; set; }
        /// <summary>
        /// Gets or sets the org_address.
        /// </summary>
        /// <value>The org_address.</value>
        public string org_address { get; set; }
        /// <summary>
        /// Gets or sets the remit_to_address.
        /// </summary>
        /// <value>The remit_to_address.</value>
        public string remit_to_address { get; set; }
        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        /// <value>The phone.</value>
        public string phone { get; set; }
        /// <summary>
        /// Gets or sets the fax.
        /// </summary>
        /// <value>The fax.</value>
        public string fax { get; set; }
        /// <summary>
        /// Gets or sets the website.
        /// </summary>
        /// <value>The website.</value>
        public string website { get; set; }
        /// <summary>
        /// Gets or sets the tax_basis.
        /// </summary>
        /// <value>The tax_basis.</value>
        public string tax_basis { get; set; }
        /// <summary>
        /// Gets or sets the is_logo_uploaded.
        /// </summary>
        /// <value>The is_logo_uploaded.</value>
        public string is_logo_uploaded { get; set; }
        /// <summary>
        /// Gets or sets the user_role.
        /// </summary>
        /// <value>The user_role.</value>
        public string user_role { get; set; }
        /// <summary>
        /// Gets or sets the user_status.
        /// </summary>
        /// <value>The user_status.</value>
        public string user_status { get; set; }
        /// <summary>
        /// Gets or sets the unverified_email.
        /// </summary>
        /// <value>The unverified_email.</value>
        public string unverified_email { get; set; }
        /// <summary>
        /// Gets or sets the is_transaction_available.
        /// </summary>
        /// <value>The is_transaction_available.</value>
        public string is_transaction_available { get; set; }
        /// <summary>
        /// Gets or sets the show_org_address_as_one_field.
        /// </summary>
        /// <value>The show_org_address_as_one_field.</value>
        public string show_org_address_as_one_field { get; set; }
        /// <summary>
        /// Gets or sets the companyid_label.
        /// </summary>
        /// <value>The companyid_label.</value>
        public string companyid_label { get; set; }
        /// <summary>
        /// Gets or sets the companyid_value.
        /// </summary>
        /// <value>The companyid_value.</value>
        public string companyid_value { get; set; }
        /// <summary>
        /// Gets or sets the taxid_label.
        /// </summary>
        /// <value>The taxid_label.</value>
        public string taxid_label { get; set; }
        /// <summary>
        /// Gets or sets the taxid_value.
        /// </summary>
        /// <value>The taxid_value.</value>
        public string taxid_value { get; set; }
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public string value { get; set; }
    }
}
