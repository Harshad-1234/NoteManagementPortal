using NoteManagementPortal.Models;
using NoteManagementPortal.Service.Interface;
using System.Text;
using System.Text.Json;

namespace NoteManagementPortal.Service
{
    public class APIService : IAPIService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public APIService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<LoginResponse> Login(LoginRequest request)
        {
            var API_URL = String.Concat(_configuration.GetValue<string>("Urls:NotesManagementAPIUrl"), CommonConstant.END_POINT_Login); 

            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(API_URL, request);

            if(!response.IsSuccessStatusCode) 
            {

                return null;
            }

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<LoginResponse>();
        }


        public async Task<GetAllNotesByUserIdResponse> GetAllNotesByUserId(int UserId , string AccessToken)
        {
            var API_URL = String.Concat(_configuration.GetValue<string>("Urls:NotesManagementAPIUrl"), CommonConstant.END_POINT_GetAllNotesByUserId);

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, API_URL);

            request.Headers.Add("UserId", UserId.ToString()); 
            request.Headers.Add("AccessToken", AccessToken);

            HttpResponseMessage response = await _httpClient.SendAsync(request);


            if (!response.IsSuccessStatusCode)
            {

                return null;
            }

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<GetAllNotesByUserIdResponse>();
        }




        public async Task<bool> RegisterUser(RegisterUesrRequest registerUesrRequest)
        {

            var API_URL = String.Concat(_configuration.GetValue<string>("Urls:NotesManagementAPIUrl"), CommonConstant.END_POINT_RegisterUser);
            
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(API_URL, registerUesrRequest);


            if (!response.IsSuccessStatusCode)
            {

                return false;
            }

            response.EnsureSuccessStatusCode();

            return true;

        }


            public async Task<bool> DeleteNote(int NoteId, int UserId, string AccessToken)
        {
            var API_URL = String.Concat(_configuration.GetValue<string>("Urls:NotesManagementAPIUrl"), CommonConstant.END_POINT_DeleteNote);

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, API_URL + NoteId);

         
            request.Headers.Add("UserId", UserId.ToString());
            request.Headers.Add("AccessToken", AccessToken);


            HttpResponseMessage response = await _httpClient.SendAsync(request);


            if (!response.IsSuccessStatusCode)
            {

                return false;
            }

            response.EnsureSuccessStatusCode();

            return true;
        }



        public async Task<UesrProfileResponse> GetUserProfile(int UserId, string AccessToken)
        {
            var API_URL = String.Concat(_configuration.GetValue<string>("Urls:NotesManagementAPIUrl"), CommonConstant.END_POINT_GetUserProfile);

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, API_URL);

            request.Headers.Add("UserId", UserId.ToString());
            request.Headers.Add("AccessToken", AccessToken);

            HttpResponseMessage response = await _httpClient.SendAsync(request);


            if (!response.IsSuccessStatusCode)
            {

                return null;
            }

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<UesrProfileResponse>();
        }


    }
}
