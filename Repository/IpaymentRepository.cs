using PaymentGateway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.Repository
{
    public interface IpaymentRepository
    {

        Task<bool> addPaymentDetails(Payment payment);


        Task<Payment> getPaymentDetails(int merchantID, String payID) ;

        Task<int> authenticateApiKey(string apiKey);

    }
}
