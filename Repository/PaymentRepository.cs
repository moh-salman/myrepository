using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PaymentGateway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.Repository
{
    public class PaymentRepository : IpaymentRepository
    {

        private readonly PaymentDBContext _context;
        private readonly ILogger<PaymentRepository> _logger;

        public PaymentRepository(PaymentDBContext context,ILogger<PaymentRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> addPaymentDetails(Payment payment)
        {
            bool status;
            _context.Payment.Add(payment);
            try
            {
                await _context.SaveChangesAsync();
                status = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                status = false;
            }

            return status;
        }

        public async Task<int> authenticateApiKey(string apiKey)
        {
            int merchantID;
            try
            {
                return merchantID = await _context.Merchant.Where(e => e.Apikey == apiKey).Select(e=>e.Merchantid).FirstOrDefaultAsync();
            }
            catch (ArgumentNullException)
            {
                return -1;
            }
            
        }

        public async Task<Payment> getPaymentDetails(int merchantID, string payID)
        {
            
            try
            {
                //Include(p=>p.Merchant) to include merchant entity also
                return  await _context.Payment.Where(p => p.Paymentid == payID && p.Merchantid== merchantID).FirstOrDefaultAsync();
            }
            catch (ArgumentNullException)
            {
                throw new Exception("Invalid identifier or not authorized!");
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                throw new Exception("An error occured");
            }
            
        }

      

       

    }
}
