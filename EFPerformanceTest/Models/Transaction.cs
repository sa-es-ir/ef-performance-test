namespace EFPerformanceTest.Models
{
    /// <summary>
    /// transaction model
    /// </summary>
    public class Transaction : ModelBase
    {
        /// <summary>
        /// transaction date
        /// </summary>
        public DateTime TransactionDate { get; set; }

        /// <summary>
        /// quantity
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// order number
        /// </summary>
        public long OrderNumber { get; set; }

        /// <summary>
        /// net revenue in euro
        /// </summary>
        public decimal NetRevenueEur { get; set; }

        /// <summary>
        /// order type
        /// </summary>
        public string OrderType { get; set; }

        /// <summary>
        /// order position type
        /// </summary>
        public string OrderPositionType { get; set; }

        /// <summary>
        /// alliance id
        /// </summary>
        public long AllianceId { get; set; }

        /// <summary>
        /// customer id
        /// </summary>
        public long CustomerId { get; set; }

        /// <summary>
        /// customer object
        /// </summary>
        public Customer Customer { get; set; }

        /// <summary>
        /// product id
        /// </summary>
        public string ProductId { get; set; }


        private string _checkSum;

        /// <summary>
        /// hash md5 of all property values
        /// </summary>
        public string CheckSum
        {
            get => _checkSum;
            set => _checkSum = value;
        }
    }
}