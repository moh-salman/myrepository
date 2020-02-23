using System;
using System.Collections.Generic;

namespace PaymentGateway.Models
{
    public partial class Merchant
    {
        public Merchant()
        {
            Payment = new HashSet<Payment>();
        }

        public int Merchantid { get; set; }
        public string Apikey { get; set; }

        public virtual ICollection<Payment> Payment { get; set; }
    }
}
