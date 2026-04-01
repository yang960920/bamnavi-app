using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using System;
using Newtonsoft.Json;

namespace SSM.Models
{
    [Table("Characters")]
    public class Character : BaseModel
    {
        [PrimaryKey("id", false)]
        public long Id { get; set; }

        [Column("AdventureId")]
        public long AdventureId { get; set; }

        [Column("Char_name")]
        public string Char_name { get; set; } = string.Empty;

        // 🚩 API 기준 서버 ID (cain, bakal 등)
        [Column("server_id")]
        public string ServerId { get; set; } = string.Empty;

        [Column("df_char_id")]
        public string? DfCharId { get; set; }

        [Column("Job")]
        public string Job { get; set; } = string.Empty;

        [Column("Spec")]
        public double? Spec { get; set; } = 0;

        [Column("Is_support")]
        public bool Is_Support { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // --- 헬퍼: 서버 ID를 한글명으로 변환 ---
        // --- 헬퍼: 서버 ID를 한글명으로 변환 ---

        [Newtonsoft.Json.JsonIgnore] // 🚩 위치 수정: 반드시 ServerName '바로 위'에 있어야 합니다!
        public string ServerName => GetServerName(ServerId);

        public static string GetServerName(string serverId) => serverId switch
        {
            "anton" => "안톤",
            "bakal" => "바칼",
            "cain" => "카인",
            "casillas" => "카시야스",
            "diregie" => "디레지에",
            "hilder" => "힐더",
            "prey" => "프레이",
            "siroco" => "시로코",
            _ => serverId // 매칭 안되면 코드 그대로 출력
        };

        // --- 🚩 UI 드롭다운용 서버 목록 데이터 ---
        public static List<KeyValuePair<string, string>> ServerList => new()
        {
            new("cain", "카인"),
            new("bakal", "바칼"),
            new("siroco", "시로코"),
            new("prey", "프레이"),
            new("hilder", "힐더"),
            new("casillas", "카시야스"),
            new("diregie", "디레지에"),
            new("anton", "안톤")
        };
    }
}