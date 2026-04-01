using Newtonsoft.Json;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace SSM.Models
{
	[Table("raid_groups")]
	public class RaidGroupUpdateDto : BaseModel
	{
		// Where(x => x.Id == ...) 필터링용
		[PrimaryKey("id", false)]
		[JsonIgnore] // INSERT/UPDATE 바디로는 안 보내기
		public int Id { get; set; }

		[Column("raid_meta_id")]
		public int RaidMetaId { get; set; }

		[Column("raid_date")]
		public string RaidDate { get; set; } = ""; // "yyyy-MM-dd"

		[Column("raid_time")]
		public TimeSpan RaidTime { get; set; }

		[Column("leader_id")]
		public long LeaderId { get; set; } // bigint

		[Column("description")]
		public string? Description { get; set; }

		[Column("max_dealer")]
		public int MaxDealer { get; set; }

		[Column("max_buffer")]
		public int MaxBuffer { get; set; }

		[Column("is_closed")]
		public bool IsClosed { get; set; }
	}
}
