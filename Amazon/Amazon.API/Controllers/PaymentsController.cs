using Amazon.Core.Entities;
using Amazon.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Amazon.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PaymentsController
	{
		private readonly IPaymentServices paymentServices;

		public PaymentsController(IPaymentServices paymentServices)
		{
			this.paymentServices = paymentServices;
		}

		[Authorize]
		[HttpPost("{basketId}")]
		public async Task<ActionResult<CustomerBasket>> CreateOrUpdatePaymentIntent(string basketId)
		{
			return await paymentServices.CreateOrUpdatePayment(basketId);
		}
    }
}
