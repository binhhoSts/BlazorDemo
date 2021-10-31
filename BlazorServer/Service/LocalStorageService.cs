using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorServer.Service
{
    public class LocalStorageService
    {
        private IJSRuntime _jsRuntime;
        string userIdKey = "userIdKey";

        public LocalStorageService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task LogOut()
        {
            await RemoveItem(userIdKey);
        }

        public async Task<Guid?> GetCurrentUserId()
        {
            return await GetItem<Guid?>(userIdKey);
        }

        public async Task SetCurrentUserId(Guid id)
        {
            await SetItem(userIdKey, id);
        }
        
        public async Task<T> GetItem<T>(string key)
        {
            var json = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", key);

            if (json == null)
            {
                return default;
            }

            return JsonSerializer.Deserialize<T>(json);
        }

        public async Task SetItem<T>(string key, T value)
        {
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", key, JsonSerializer.Serialize(value));
        }

        public async Task RemoveItem(string key)
        {
            await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", key);
        }
    }
}
