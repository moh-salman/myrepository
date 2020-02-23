using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.Models
{
    public class PaymentDetails
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


        public PaymentDetails(string paymentId,int? merchantId,string cardNumber,string cardHolderName,string cardType,string expiryDate,int? status,double? amount,DateTime paymentDate,string currency)
        {
            Cardnumber = cardNumber;
            Cardholdername = cardHolderName;
            Cardtype = cardType;
            Expirydate = expiryDate;
            Status = status;
            Merchantid = merchantId;
            Paymentid = paymentId;
            Amount = amount;
            Paymentdate = paymentDate;
            Currency = currency;
        }

    }
}
