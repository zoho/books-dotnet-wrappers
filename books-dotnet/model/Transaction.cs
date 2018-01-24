using System.Collections.Generic;

namespace zohobooks.model
{
    /// <summary>
    ///     Used to define the model object of BankTransaction.
    /// </summary>
    public class Transaction
    {
        /// <summary>
        ///     Gets or sets the transaction_id.
        /// </summary>
        /// <value>The transaction_id.</value>
        public string transaction_id { get; set; }

        /// <summary>
        ///     Gets or sets the debit_or_credit.
        /// </summary>
        /// <value>The debit_or_credit.</value>
        public string debit_or_credit { get; set; }

        /// <summary>
        ///     Gets or sets the date.
        /// </summary>
        /// <value>The date.</value>
        public string date { get; set; }

        /// <summary>
        ///     Gets or sets the customer_id.
        /// </summary>
        /// <value>The customer_id.</value>
        public string customer_id { get; set; }

        /// <summary>
        ///     Gets or sets the payee.
        /// </summary>
        /// <value>The payee.</value>
        public string payee { get; set; }

        /// <summary>
        ///     Gets or sets the reference_number.
        /// </summary>
        /// <value>The reference_number.</value>
        public string reference_number { get; set; }

        /// <summary>
        ///     Gets or sets the transaction_type.
        /// </summary>
        /// <value>The transaction_type.</value>
        public string transaction_type { get; set; }

        /// <summary>
        ///     Gets or sets the amount.
        /// </summary>
        /// <value>The amount.</value>
        public double amount { get; set; }

        /// <summary>
        ///     Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        public string status { get; set; }

        /// <summary>
        ///     Gets or sets the source.
        /// </summary>
        /// <value>The source.</value>
        public string source { get; set; }

        /// <summary>
        ///     Gets or sets the account_id.
        /// </summary>
        /// <value>The account_id.</value>
        public string account_id { get; set; }

        /// <summary>
        ///     Gets or sets the currency_id.
        /// </summary>
        /// <value>The currency_id.</value>
        public string currency_id { get; set; }

        /// <summary>
        ///     Gets or sets the currency_code.
        /// </summary>
        /// <value>The currency_code.</value>
        public string currency_code { get; set; }

        /// <summary>
        ///     Gets or sets the offset_account_name.
        /// </summary>
        /// <value>The offset_account_name.</value>
        public string offset_account_name { get; set; }

        /// <summary>
        ///     Gets or sets the imported_transaction_id.
        /// </summary>
        /// <value>The imported_transaction_id.</value>
        public string imported_transaction_id { get; set; }

        /// <summary>
        ///     Gets or sets the from_account_id.
        /// </summary>
        /// <value>The from_account_id.</value>
        public string from_account_id { get; set; }

        /// <summary>
        ///     Gets or sets the from_account_name.
        /// </summary>
        /// <value>The from_account_name.</value>
        public string from_account_name { get; set; }

        /// <summary>
        ///     Gets or sets the to_account_id.
        /// </summary>
        /// <value>The to_account_id.</value>
        public string to_account_id { get; set; }

        /// <summary>
        ///     Gets or sets the to_account_name.
        /// </summary>
        /// <value>The to_account_name.</value>
        public string to_account_name { get; set; }

        /// <summary>
        ///     Gets or sets the payment_mode.
        /// </summary>
        /// <value>The payment_mode.</value>
        public string payment_mode { get; set; }

        /// <summary>
        ///     Gets or sets the exchange_rate.
        /// </summary>
        /// <value>The exchange_rate.</value>
        public double exchange_rate { get; set; }

        /// <summary>
        ///     Gets or sets the customer_name.
        /// </summary>
        /// <value>The customer_name.</value>
        public string customer_name { get; set; }

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string description { get; set; }

        /// <summary>
        ///     Gets or sets the status_formatted.
        /// </summary>
        /// <value>The status_formatted.</value>
        public string status_formatted { get; set; }

        /// <summary>
        ///     Gets or sets the associated_transactions.
        /// </summary>
        /// <value>The associated_transactions.</value>
        public List<Transaction> associated_transactions { get; set; }

        /// <summary>
        ///     Gets or sets the categorized_transaction_id.
        /// </summary>
        /// <value>The categorized_transaction_id.</value>
        public string categorized_transaction_id { get; set; }

        /// <summary>
        ///     Gets or sets the transaction_date.
        /// </summary>
        /// <value>The transaction_date.</value>
        public string transaction_date { get; set; }

        /// <summary>
        ///     Gets or sets the transaction_type_formatted.
        /// </summary>
        /// <value>The transaction_type_formatted.</value>
        public string transaction_type_formatted { get; set; }

        /// <summary>
        ///     Gets or sets the entry_number.
        /// </summary>
        /// <value>The entry_number.</value>
        public string entry_number { get; set; }

        /// <summary>
        ///     Gets or sets the reconcile_status.
        /// </summary>
        /// <value>The reconcile_status.</value>
        public string reconcile_status { get; set; }

        /// <summary>
        ///     Gets or sets the debit_amount.
        /// </summary>
        /// <value>The debit_amount.</value>
        public object debit_amount { get; set; }

        /// <summary>
        ///     Gets or sets the credit_amount.
        /// </summary>
        /// <value>The credit_amount.</value>
        public object credit_amount { get; set; }

        /// <summary>
        ///     Gets or sets the transaction_status.
        /// </summary>
        /// <value>The transaction_status.</value>
        public string transaction_status { get; set; }

        /// <summary>
        ///     Gets or sets the transaction_status_formatted.
        /// </summary>
        /// <value>The transaction_status_formatted.</value>
        public string transaction_status_formatted { get; set; }

        /// <summary>
        ///     Gets or sets the transaction_source.
        /// </summary>
        /// <value>The transaction_source.</value>
        public string transaction_source { get; set; }

        /// <summary>
        ///     Gets or sets the account_name.
        /// </summary>
        /// <value>The account_name.</value>
        public string account_name { get; set; }

        /// <summary>
        ///     Gets or sets the account_type.
        /// </summary>
        /// <value>The account_type.</value>
        public string account_type { get; set; }

        /// <summary>
        ///     Gets or sets the price_precision.
        /// </summary>
        /// <value>The price_precision.</value>
        public int price_precision { get; set; }

        /// <summary>
        ///     Gets or sets the currency_symbol.
        /// </summary>
        /// <value>The currency_symbol.</value>
        public string currency_symbol { get; set; }

        /// <summary>
        ///     Gets or sets the imported_transactions.
        /// </summary>
        /// <value>The imported_transactions.</value>
        public List<ImportedTransaction> imported_transactions { get; set; }
    }
}