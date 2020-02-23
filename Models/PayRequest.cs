using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.Models
{
    public class PayRequest
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$",ErrorMessage ="Invalid Name format")]
        public string CardHolderName { get; set; }
        
        [Required]
        [RegularExpression(@"^\d{13,19}$", ErrorMessage ="Invalid card number format")]
        public string Cardnumber { get; set; }
        [Required]
        [RegularExpression(@"^((0[1-9])|(1[0-2]))[\/](([2-9][0-9]))$", ErrorMessage = "Invalid expiry date format. Should be MM/YY")]
        public string ExpiryDate { get; set; }
        [Required]
        [RegularExpression(@"^\d{3}$", ErrorMessage = "Invalid CVV.  Should be 3 digits only")]
        public int Cvv { get; set; }
        [Required]
        public string CardType { get; set; }
        [Required]
        [RegularExpression(@"^[A-Za-z]{3}$", ErrorMessage = "Invalid Currency format.  Should be 3 alphabets only")]
        public string Currency { get; set; }
        [Required]
        public double Amount { get; set; }
    }
}
