using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NoteManagementPortal.Models;
using NoteManagementPortal.Service;
using NoteManagementPortal.Service.Interface;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NoteManagementPortal.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IAPIService _apiService;

        public LoginModel(IAPIService apiService)
        {
            _apiService = apiService;
        }


        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        [BindProperty]
        public string ErrorMessage { get; set; }


       
        

        public async Task<IActionResult> OnPostAsync()
        {
            

            if(String.IsNullOrEmpty(Username)) 
            {
                ErrorMessage = "Please Enter Username";
                return Page();
            }

            if (String.IsNullOrEmpty(Password)) 
            {
                ErrorMessage = "Please Enter Password";
                return Page();
            }

            LoginRequest loginRequest = new LoginRequest(); 

            loginRequest.Username = Username;
            loginRequest.Password = Password;       

            LoginResponse response = await _apiService.Login(loginRequest);

            if (response != null)
            {

                var user = new User { UserId = response.UserId, UserName = response.Username,Token  = response.AccessToken };
                var userJson = JsonSerializer.Serialize(user);

                HttpContext.Session.SetString("CurrentUser", userJson);

                TempData["UserName"] = response.Username;
              

                return RedirectToPage("/Notes");


            }
            else
            {
                ErrorMessage = "Invalid user"; 
                return Page(); 
            }

        }
        public void OnGet()
        
        {

            HttpContext.Session.Clear();
        }

    }
}
