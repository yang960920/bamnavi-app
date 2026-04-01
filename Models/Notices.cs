using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

[Table("notices")]
public class Notice : BaseModel
{
	[PrimaryKey("id", false)]
	public int Id { get; set; }

	[Column("title")]
	public string Title { get; set; } = "";

	[Column("content")]
	public string Content { get; set; } = "";

	[Column("is_active")]
	public bool IsActive { get; set; } = true;

	[Column("priority")]
	public int Priority { get; set; } = 0; // 💡 출력 순서 (낮을수록 앞순서)

	[Column("created_at")]
	public DateTime CreatedAt { get; set; } = DateTime.Now;
}