using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Supabase;
using SSM.Services;
using SSM;

// 만약 아래 구문에서 에러가 난다면 global::SSM.App 으로 시도하세요.


namespace SSM
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebAssemblyHostBuilder.CreateDefault(args);

			// App 앞에 네임스페이스를 명시적으로 붙여서 인식시킵니다.
			builder.RootComponents.Add<App>("#app");
			builder.RootComponents.Add<HeadOutlet>("head::after");

			builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
			builder.Services.AddScoped<AppState>();
	
			// MudBlazor 및 Supabase 설정
			builder.Services.AddMudServices();
			builder.Services.AddScoped<Supabase.Client>(provider =>
			{
				var url = "https://wylqswtmxqpotmqpdapt.supabase.co";
				var key = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6Ind5bHFzd3RteHFwb3RtcXBkYXB0Iiwicm9sZSI6ImFub24iLCJpYXQiOjE3NjgzMzA3MzMsImV4cCI6MjA4MzkwNjczM30.2LJfYr0_QKAWKxXIhyDVR6Ia-briZ-t6dIPPPlqYuXc";

				var options = new Supabase.SupabaseOptions
				{
					AutoRefreshToken = true,
					AutoConnectRealtime = true
				};

				return new Supabase.Client(url, key, options);
			});

			await builder.Build().RunAsync();

		}
	}
}