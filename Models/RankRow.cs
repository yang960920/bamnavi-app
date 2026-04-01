namespace SSM.Models
{
	public class RankRow
	{
		public int AdventureId { get; set; }
		public string AdventureName { get; set; } = "";
		public string CharName { get; set; } = "";
		public string Job { get; set; } = "";
		public double Spec { get; set; }
		public bool IsSupport { get; set; }
		public double DiffDay { get; set; }    // 1일 증감
		public double DiffMonth { get; set; }  // 월간 증감
		public int RankDiff { get; set; }      // 순위 변동
	}
}