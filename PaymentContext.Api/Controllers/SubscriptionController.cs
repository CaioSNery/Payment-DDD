using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PaymentContext.Domain.Command;
using PaymentContext.Domain.Handlers;
using PaymentContext.Domain.Repositories;
using PaymentContext.Shared.Dtos;

namespace PaymentContext.Api.Controllers
{
    [ApiController]
    [Route("v1")]
    public class SubscriptionController : ControllerBase
    {
        private readonly IStudentRepository _repository;
        private readonly SubscriptionHandler _handler;

        public SubscriptionController(IStudentRepository repository, SubscriptionHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        [HttpPost("subscriptions/boleto")]
        public IActionResult CreateBoletoSubscription([FromBody] CreateBoletoSubscriptionCommand command)
        {
            var result = _handler.Handle(command);
            if (!result.Sucess)
                return BadRequest(result);

            return Ok(new { message = result });
        }

        [HttpPost("subscriptions/paypal")]
        public IActionResult CreatePaypalSubsctiption([FromBody] CreatePaypalSubscriptionCommand command)
        {
            var result = _handler.Handle(command);
            if (!result.Sucess)
                return BadRequest(result);

            return Ok(new { message = result });
        }

        [HttpPost("subscriptions/creditcard")]
        public IActionResult CreateCreditCardSubscription([FromBody] CreateCreditCardSubscriptionCommand command)
        {
            var result = _handler.Handle(command);
            if (!result.Sucess)
                return BadRequest(result);

            return Ok(new { message = result });
        }
    }
}