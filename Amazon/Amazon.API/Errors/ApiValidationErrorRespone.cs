namespace Amazon.API.Errors
{
	public class ApiValidationErrorRespone:BaseCommonResponse
	{
        public ApiValidationErrorRespone():base(400)
        {
            
        }
        public IEnumerable<string> Errors { get; set; }
    }
}
