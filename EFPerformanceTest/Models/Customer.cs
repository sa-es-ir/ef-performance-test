namespace EFPerformanceTest.Models
{
    /// <summary>
    /// customer model
    /// </summary>
    public class Customer : ModelBaseNoId
    {
        /// <summary>
        /// id as customer id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// customer name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// country
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// street
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// city
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// postal code
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// customer value
        /// </summary>
        public decimal CustomerValue { get; set; }

        /// <summary>
        /// customer email
        /// </summary>
        public string CustomerUserId { get; set; }

        /// <summary>
        /// duns number
        /// </summary>
        public int? DunsNr { get; set; }

        /// <summary>
        /// is deleted
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// employee count
        /// </summary>
        public int CountEmployee { get; set; }

        /// <summary>
        /// industrial employee count
        /// </summary>
        public int CountIndustrialEmployee { get; set; }

        /// <summary>
        /// customer id
        /// </summary>
        public string CustomerCrmId { get; set; }

        /// <summary>
        /// classification
        /// </summary>
        public string Classification { get; set; }

        /// <summary>
        /// customer strategy
        /// </summary>
        public string CustomerStrategy { get; set; }


        /// <summary>
        /// will be filled after customer activity imported and this is the last CompletedOn date for this customer
        /// </summary>
        public DateTime? LastActivityDate { get; set; }

        /// <summary>
        /// industry branch id
        /// </summary>
        public string IndustryBranchId { get; set; }


        /// <summary>
        /// alliance id
        /// </summary>
        public long AllianceId { get; set; }


        /// <summary>
        /// all customer transactions
        /// </summary>
        public List<Transaction> Transactions { get; set; }

    }
}
