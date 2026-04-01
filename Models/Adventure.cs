using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace SSM.Models
{

	[Table("Adventure")]
	public class Adventure : BaseModel
	{
		[PrimaryKey("id", false)]
		public long Id { get; set; }

		[Column("Adventure_Name")]
		public string AdventureName { get; set; } = string.Empty;

		[Column("PW")]
		public string Password { get; set; } = string.Empty;

		[Column("is_admin")] public bool IsAdmin { get; set; }

	}
}