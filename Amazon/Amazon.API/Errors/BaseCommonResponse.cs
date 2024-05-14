
namespace Amazon.API.Errors
{
	public class BaseCommonResponse
	{
        public BaseCommonResponse(int statusCode, string message=null)
        {
			StatusCode = statusCode;
			Message = message??DefaultMessageForStatusCode(statusCode);
        }

		private string DefaultMessageForStatusCode(int statusCode)
		{
			return statusCode switch
			{
				400 => "Bad Request",
				401 => "Not Authorize",
				404 => "Resource Not Found",
				500 => "Server Not Found",
				_ => null
			};
		}

		public int StatusCode { get; set; }
		public string Message { get; set; }
	}
}
