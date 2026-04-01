using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using System;

namespace SSM.Models
{
	[Table("Character_History")] // 🚩 DB 테이블 이름과 정확히 일치해야 함
	public class CharacterHistory : BaseModel
	{
		[PrimaryKey("id", false)]
		public long Id { get; set; }

		[Column("AdventureId")]
		public long AdventureId { get; set; }

		[Column("Char_name")]
		public string Char_name { get; set; } = string.Empty;

		[Column("Job")]
		public string Job { get; set; } = string.Empty;

		[Column("Spec")]
		public double? Spec { get; set; }

		[Column("Is_support")]
		public bool Is_Support { get; set; }

		[Column("log_date")] // 🚩 우리가 새로 추가한 날짜 컬럼
		public DateTime LogDate { get; set; }

		[Column("created_at")]
		public DateTime CreatedAt { get; set; }
	}
}