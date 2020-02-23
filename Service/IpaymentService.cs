using PaymentGateway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.Service
{
    public interface IpaymentService
    {
        Task<bool> addPaymentDetails(Payment payment);

        Task<BankResponse> makePayment(PayRequest payReq);

        Task<PaymentDetails> getPaymentDetails(int merchantID, String payID);

        Task<int> authenticateApiKey(string apiKey);
    }
}
