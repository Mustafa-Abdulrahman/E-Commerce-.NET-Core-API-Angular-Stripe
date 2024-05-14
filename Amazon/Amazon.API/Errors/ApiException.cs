namespace Amazon.API.Errors
{
	public class ApiException : BaseCommonResponse
	{
		public ApiException( string _details,int statusCode, string message = null) : base(statusCode, message)
		{
			Details= _details;
		}
		public string Details { get; set; }
	}
}
