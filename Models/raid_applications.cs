using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using System.ComponentModel.DataAnnotations.Schema;
using ColumnAttribute = Supabase.Postgrest.Attributes.ColumnAttribute;
using TableAttribute = Supabase.Postgrest.Attributes.TableAttribute;

namespace SSM.Models
{
	[Table("raid_applications")]
	public class RaidApplication : BaseModel
	{
		[PrimaryKey("id", false)]
		public int Id { get; set; }

		[Column("raid_id")]
		public int RaidId { get; set; }

		[Column("character_id")]
		public int CharacterId { get; set; }

		[Column("adventure_id")]
		public int AdventureId { get; set; }



		[Column("status")]
		public string Status { get; set; } = "대기";

		[Column("party_no")]
		public int PartyNo { get; set; } = 0;

		[Column("applied_at")]
		public DateTimeOffset AppliedAt { get; set; }


	}
}
