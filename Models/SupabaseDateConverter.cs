using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SSM.Models // 프로젝트 네임스페이스에 맞게 조정하세요
{
	public class SupabaseDateConverter : IsoDateTimeConverter
	{
		public SupabaseDateConverter()
		{
			// 💡 Supabase(PostgreSQL)의 date 타입에 맞게 
			// 시간대 연산을 무시하고 문자열 그대로 전송하도록 형식을 강제합니다.
			DateTimeFormat = "yyyy-MM-dd";
		}
	}
}