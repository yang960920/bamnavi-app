using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using Newtonsoft.Json;
using System.Globalization;

namespace SSM.Models
{
	[Table("raid_groups")]
	public class RaidGroup : BaseModel
	{
		[PrimaryKey("id", false)]
		public int Id { get; set; }

		[Column("raid_meta_id")]
		public int RaidMetaId { get; set; }

		[Column("raid_date")]
		public string RaidDateStr { get; set; } = "";

		[JsonIgnore]
		public DateTime RaidDate
		{
			get
			{
				if (string.IsNullOrWhiteSpace(RaidDateStr)) return default;
				return DateTime.ParseExact(RaidDateStr, "yyyy-MM-dd", CultureInfo.InvariantCulture);
			}
			set
			{
				RaidDateStr = value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
			}
		}

		[Column("raid_time")]
		public TimeSpan RaidTime { get; set; }

		[Column("leader_id")]
		public long LeaderId { get; set; }

		[Column("description")]
		public string? Description { get; set; }

		[Column("created_at")]
		public DateTimeOffset? CreatedAt { get; set; }

		[Column("max_dealer")]
		public int MaxDealer { get; set; }

		[Column("max_buffer")]
		public int MaxBuffer { get; set; }

		[Column("is_closed")]
		public bool IsClosed { get; set; } = false;

		// 🚩 [추가] 벞교 여부 및 단위 컬럼 매핑
		[Column("is_bundle")]
		public bool IsBundle { get; set; } = false;

		[Column("bundle_size")]
		public int BundleSize { get; set; } = 1; // 기본값 1로 설정하여 일반 레이드 대응
	}
}