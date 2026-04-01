using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace SSM.Models
{
	[Table("raid_meta")]
	public class RaidMeta : BaseModel
	{
		[PrimaryKey("id", false)] public int Id { get; set; }
		[Column("raid_name")] public string RaidName { get; set; }
		[Column("max_players")] public int MaxPlayers { get; set; }
		[Column("is_active")] public bool IsActive { get; set; }
		[Column("default_dealer")] public int DefaultDealer { get; set; }
		[Column("default_buffer")] public int DefaultBuffer { get; set; }
	}
}
