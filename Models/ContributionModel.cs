using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace SSM.Models
{
    public class MemberContribution
    {
        [JsonPropertyName("adventure_id")]
        public long AdventureId { get; set; }

        [JsonPropertyName("adventure_name")]
        public string AdventureName { get; set; }

        [JsonPropertyName("attendance_rate")]
        public double AttendanceRate { get; set; }        // 누적 성실도

        [JsonPropertyName("recent_heat")]
        public double RecentForm { get; set; }            // 최근 활동 (이름 달라도 매핑됨)

        [JsonPropertyName("labor_supply")]
        public double LaborContribution { get; set; }     // 노동 기여

        [JsonPropertyName("roster_mobilization")]
        public double MobilizationEfficiency { get; set; } // 동원 효율

        [JsonPropertyName("elite_dedication")]
        public double EliteDedication { get; set; }       // 본캐 헌신

        [JsonPropertyName("absolute_power")]
        public double AbsolutePower { get; set; }         // 절대 무력

        [JsonPropertyName("total_score")]
        public double TotalScore { get; set; }            // 총합 기여도

        [JsonPropertyName("personalized_mentions")]
        public List<string> Mentions { get; set; } = new();
    }
}