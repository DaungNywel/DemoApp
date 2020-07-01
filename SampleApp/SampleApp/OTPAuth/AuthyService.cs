using Newtonsoft.Json;
using SampleApp.Helpers;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp.OTPAuth
{
    public class AuthyService
    {
        private static readonly HttpClient client = CreateHttpClient();

        private static HttpClient CreateHttpClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(Constants.AuthyBaseURL);
            client.DefaultRequestHeaders.Add("X-Authy-API-Key", Constants.AuthyAPIKey);
            return client;
        }

        public static async Task<AuthyUserResponse> AddUser(CompanyUser user)
        {
            var requestContent = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("user[email]", user.Email),
                new KeyValuePair<string, string>("user[cellphone]", user.Cellphone),
                new KeyValuePair<string, string>("user[country_code]", user.CountryCode),
            });

            var response = await client.PostAsync(Constants.AddUserURL, requestContent);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var authyUser = JsonConvert.DeserializeObject<AuthyUserResponse>(content);

                return authyUser;
            }

            return default;
        }

        public static async Task<AuthyOTPResponse> SendOTP(long authyID)
        {
            var response = await client.GetAsync($"{Constants.SendOTPURL}/{authyID}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var authyOTP = JsonConvert.DeserializeObject<AuthyOTPResponse>(content);

                return authyOTP;
            }

            return default;
        }

        public static async Task<AuthyVerifyResponse> VerifyToken(long token, long authyID)
        {
            var response = await client.GetAsync($"{Constants.VerifyTokenURL}/{token}/{authyID}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var authyVerify = JsonConvert.DeserializeObject<AuthyVerifyResponse>(content);

                return authyVerify;
            }

            return default;
        }
    }
}
