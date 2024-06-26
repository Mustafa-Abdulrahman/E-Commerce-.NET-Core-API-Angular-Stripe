﻿using System.ComponentModel.DataAnnotations;

namespace Amazon.API.Dtos
{
	public class RegisterDto
	{
		[Required]
		[EmailAddress]
		public string Email {  get; set; }
		[Required]
		[MinLength(3,ErrorMessage ="Min Length 3")]
		public string DisplayName {  get; set; }
		[Required]
		[RegularExpression("(?=^.{6,10}$)(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\\s).*$",ErrorMessage = "expects atleast 1 small-case letter, 1 Capital letter, 1 digit, 1 special character and the length should be between 6-10 characters")]
		public string Password { get; set; }
	}
}
