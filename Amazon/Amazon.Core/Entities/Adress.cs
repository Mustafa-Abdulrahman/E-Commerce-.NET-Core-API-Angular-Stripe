using System.ComponentModel.DataAnnotations.Schema;

namespace Amazon.Core.Entities
{
	public class Adress
	{
		public int Id {  get; set; }
		public string FirstName { get; set; }
		public string LasttName { get; set; }
		public string Street { get; set; }
		public string City { get; set; }
		public string Satate { get; set; }
		public string ZibCode { get; set; }
		[ForeignKey(nameof(AppUser))]
		public string AppUserId { get; set; }
		public virtual AppUser AppUser { get; set; }
	}
}