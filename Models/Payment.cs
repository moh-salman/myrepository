using System;
using System.Collections.Generic;

namespace PaymentGateway.Models
{
    public partial class Payment
    {
        public string Paymentid { get; set; }
        public int? Merchantid { get; set; }
        public string Cardnumber { get; set; }
        public string Cardholdername { get; set; }
        public string Cardtype { get; set; }
        public string Expirydate { get; set; }
        public int? Status { get; set; }
        public double? Amount { get; set; }
        public DateTime Paymentdate { get; set; }
        public string Currency { get; set; }

        public virtual Merchant Merchant { get; set; }
    }
}
