using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PaymentGateway.Models;
using PaymentGateway.Service;
using PaymentGateway.Validators;

namespace PaymentGateway.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IpaymentService _paymentService;

        public PaymentsController(IpaymentService paymentService)
        {
            _paymentService = paymentService;
        }



        // GET: api/v1/Payments/5dfdcb14-21ee-460c-a5e7-e1ac5f8e7ed5
        [HttpGet("{payID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PaymentDetails>> GetPayment(string payID)
        {
            int merchantID = await Authenticate();
            if (merchantID == -3)
            {
                return BadRequest("An error occured.");
            }
            if (merchantID < 0)
            {
                return Unauthorized();
            }
            PaymentDetails paymentDetails;

            try
            {
               paymentDetails= await _paymentService.getPaymentDetails(merchantID, payID);
               return Ok(paymentDetails);
            }
            catch(Exception ex)
            {
                return Unauthorized(ex.Message);
            }
            
            
        }

        

        // POST: api/Payments
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BankResponse>> PostPaymentToBank(PayRequest payReq)
        {
            int merchantID = await Authenticate();
            if (merchantID == -3)
            {
                return BadRequest("An error occured.");
            }
            if (merchantID < 0)
            {
                return Unauthorized();
            }
            

            if (payReq == null)
            {
                return BadRequest();
            }
            //automatically done by web api controller
            /*if (!ModelState.IsValid)
            {
                return BadRequest();
            }*/
            
            
            try
            {
                CardValidator.validateCard(payReq);
                payReq.Cardnumber = payReq.Cardnumber.Replace(" ", "");
                BankResponse bankResponse = new BankResponse();
                bankResponse = await _paymentService.makePayment(payReq);
                Payment payment = new Payment()
                {
                    Status = bankResponse.Status,
                    Paymentid = bankResponse.Identifier,
                    Merchantid=merchantID,
                    Amount=payReq.Amount,
                    Expirydate=payReq.ExpiryDate,
                    Cardholdername=payReq.CardHolderName,
                    Cardnumber=payReq.Cardnumber,
                    Cardtype=payReq.CardType,
                    Currency=payReq.Currency
                };
                await _paymentService.addPaymentDetails(payment);
                if (bankResponse.Status == 1000)
                {
                    return Ok(bankResponse);
                }
                return BadRequest(bankResponse);
             }catch(Exception e)
             {
                 return BadRequest(e.Message);
             }
           
        }


        private async Task<int> Authenticate()
        {
            string key = Request.Headers["ApiKey"];
            if (key == null)
            {
                return -2;
            }
            try
            {
                return await _paymentService.authenticateApiKey(key);
            }
            catch (Exception)
            {
                return -3;
            }
            
        }
    }
}
