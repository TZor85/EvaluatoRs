using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;


namespace AdminApp.Data
{
    public class TokenContainer
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TokenContainer(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task AddRequestHeaders(HttpClient httpClient)
        {

            var accessToken = await _httpContextAccessor.HttpContext.GetTokenAsync("access_token");

            var data = _httpContextAccessor.HttpContext.User;

            httpClient.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        }

        public async Task<string> GetAccessToken()
        {
            return await GetToken("access_token");
        }

        public async Task<string> GetAccessTokenId()
        {
            return await GetToken("id_token");
        }

        public Dictionary<string, string> GetClaims()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            var data = _httpContextAccessor.HttpContext.User.Claims;

            foreach (var item in data)
            {
                result.Add(item.Type, item.Value);
            }
            return result;
        }

        private async Task<string> GetToken(string requestToken)
        {
            var data = await _httpContextAccessor.HttpContext.GetTokenAsync(requestToken);
            return data;
        }
    }
}