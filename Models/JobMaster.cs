using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace SSM.Models
{
	[Table("job_master")]
	public class JobMaster : BaseModel
	{
		[PrimaryKey("id", false)]
		public long Id { get; set; }

		[Column("job_name")]
		public string JobName { get; set; } = "";

		[Column("is_support")]
		public bool IsSupport { get; set; }

		[Column("is_active")] // 💡 추가된 컬럼
		public bool IsActive { get; set; } = true;

		[Column("created_at")]
		public DateTime CreatedAt { get; set; }
	}
}
