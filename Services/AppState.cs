using Microsoft.JSInterop;
using SSM.Models;
using System;
using System.Collections.Generic; // 💡 List 사용을 위해 추가
using System.Threading.Tasks;

namespace SSM.Services
{
	public class AppState
	{
		private readonly IJSRuntime _js;

		public AppState(IJSRuntime js)
		{
			_js = js;
		}

		public long CurrentUserId { get; private set; }
		public long CurrentAdventureId { get; private set; }
		public string CurrentAdventureName { get; private set; } = "";
		public bool IsAdmin { get; private set; }

		// 🚩 직업 목록을 앱 전체에서 공유하기 위한 캐시 변수 추가
		public List<JobMaster> CachedJobMasters { get; set; } = new();

		public bool IsLoggedIn => CurrentUserId > 0;

		public void SetLogin(long id, string name, bool isAdmin)
		{
			CurrentUserId = id;
			CurrentAdventureId = id;
			CurrentAdventureName = name;
			IsAdmin = isAdmin;
			NotifyStateChanged();
		}

		public void Logout()
		{
			CurrentUserId = 0;
			CurrentAdventureId = 0;
			CurrentAdventureName = "";
			IsAdmin = false;
			NotifyStateChanged();
		}

		public async Task PersistLogin()
		{
			if (CurrentUserId > 0)
			{
				await _js.InvokeVoidAsync("localStorage.setItem", "userId", CurrentUserId.ToString());
				await _js.InvokeVoidAsync("localStorage.setItem", "advId", CurrentAdventureId.ToString());
				await _js.InvokeVoidAsync("localStorage.setItem", "advName", CurrentAdventureName);
				await _js.InvokeVoidAsync("localStorage.setItem", "isAdmin", IsAdmin.ToString());
			}
		}

		public async Task<bool> TryRestoreLogin()
		{
			try
			{
				var storedId = await _js.InvokeAsync<string>("localStorage.getItem", "userId");
				var storedAdvId = await _js.InvokeAsync<string>("localStorage.getItem", "advId");
				var storedName = await _js.InvokeAsync<string>("localStorage.getItem", "advName");
				var storedAdmin = await _js.InvokeAsync<string>("localStorage.getItem", "isAdmin");

				if (!string.IsNullOrEmpty(storedId) && long.TryParse(storedId, out long id))
				{
					CurrentUserId = id;
					CurrentAdventureId = long.TryParse(storedAdvId, out long advId) ? advId : id;
					CurrentAdventureName = storedName ?? "Unknown";
					IsAdmin = storedAdmin == "True";
					NotifyStateChanged();
					return true;
				}
			}
			catch { }
			return false;
		}

		public async Task ClearStorage()
		{
			await _js.InvokeVoidAsync("localStorage.removeItem", "userId");
			await _js.InvokeVoidAsync("localStorage.removeItem", "advId");
			await _js.InvokeVoidAsync("localStorage.removeItem", "advName");
			await _js.InvokeVoidAsync("localStorage.removeItem", "isAdmin");
			Logout();
		}

		public event Action? OnChange;
		public void NotifyStateChanged() => OnChange?.Invoke();

		public void UpdateAdventureName(string newName)
		{
			CurrentAdventureName = newName;
			NotifyStateChanged();
		}

		public void UpdateAdminStatus(bool isAdmin)
		{
			IsAdmin = isAdmin;
			NotifyStateChanged();
		}
		public void NotifyNoticeChanged()
		{
			NotifyStateChanged();
		}
	}
}