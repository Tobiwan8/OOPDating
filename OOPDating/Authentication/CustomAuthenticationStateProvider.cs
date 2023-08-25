using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Security.Claims;
using OOPDating.Entities;

namespace OOPDating.Authentication
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ProtectedSessionStorage _sessionStorage;
        private ClaimsPrincipal _anonymous = new(new ClaimsIdentity());

        public CustomAuthenticationStateProvider(ProtectedSessionStorage sessionStorage)
        {
            _sessionStorage = sessionStorage;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var UserSessionStorageResult = await _sessionStorage.GetAsync<Account>("Account");
                var Account = UserSessionStorageResult.Success ? UserSessionStorageResult.Value : null;
                if (Account == null)
                {
                    return await Task.FromResult(new AuthenticationState(_anonymous));
                }
                var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Name, Account.AccountName)
                }, "CustomAuth"));
                return await Task.FromResult(new AuthenticationState(claimsPrincipal));
            }
            catch
            {
                return await Task.FromResult(new AuthenticationState(_anonymous));
            }
        }

        public async Task UpdateAuthenticationState(Account account)
        {
            ClaimsPrincipal claimsPrincipal;

            if(account != null)
            {
                await _sessionStorage.SetAsync("Account", account);
                claimsPrincipal = new(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Name, account.AccountName)
                }));
            }
            else
            {
                await _sessionStorage.DeleteAsync("Account");
                claimsPrincipal = _anonymous;
            }

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }
    }
}
