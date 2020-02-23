using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.Models
{
    public class BankResponse
    {
        public int Status{ get; set; }
        public String Identifier { get; set; }
    }
}
