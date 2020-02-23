using PaymentGateway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PaymentGateway.Validators
{
    public class CardValidator
    {

        public static void validateCard(PayRequest payReq)
        {

            if (!checkExpiryDate(payReq.ExpiryDate))
            {
                throw new Exception("Invalid expiry date or card expired!");
            }
        }

        private static bool checkExpiryDate(string expDate)
        {
            string date = "01/" + expDate;
            DateTime dt1 = DateTime.Parse(date);
            DateTime dt2 = DateTime.Now;
            //if (dt1.Date < dt2.Date)
            //{
            //    return false;
            //}
            

            if ((dt1.Year - dt2.Year) >= 0 && (dt1.Year - dt2.Year) <= 3 && dt1.Month >= dt2.Month)
            {
                return true;
            }

            return false;
        }

    }
}
