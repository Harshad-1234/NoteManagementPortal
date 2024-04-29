using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NoteManagementPortal.Models;
using NoteManagementPortal.Service.Interface;

namespace NoteManagementPortal.Pages
{
    public class SignUpModel : PageModel
    {
        private readonly IAPIService _apiService;

        public SignUpModel(IAPIService apiService)
        {
            _apiService = apiService;
        }


        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Mobile { get; set; }
        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        [BindProperty]
        public string ConfirmPassword { get; set; }


        [BindProperty]
        public string ErrorMessage { get; set; }


        
        public void OnGet()
        {
        }


        public async Task<IActionResult> OnPostAsync()
        {

            RegisterUesrRequest registerUesrRequest = new RegisterUesrRequest();


            if(String.IsNullOrEmpty(Username)) 
            {
                ErrorMessage = String.Empty;

                ErrorMessage = "Please enter Username";

                return Page();
            }


            if (String.IsNullOrEmpty(Email))
            {
                ErrorMessage = String.Empty;

                ErrorMessage = "Please enter Email";

                return Page();
            }
            if (String.IsNullOrEmpty(Password))
            {
                ErrorMessage = String.Empty;

                ErrorMessage = "Please enter Password";

                return Page();
            }
            if (String.IsNullOrEmpty(ConfirmPassword))
            {
                ErrorMessage = String.Empty;

                ErrorMessage = "Please enter Confirm Password";

                return Page();
            }

            if (Password != ConfirmPassword)
            {


                ErrorMessage = "Password dosen't match";

                return Page();
            }

            registerUesrRequest.Username = Username;    
            registerUesrRequest.Email = Email;
            registerUesrRequest.Password = Password;
            
            registerUesrRequest.mobile = Mobile;

            var response = await _apiService.RegisterUser(registerUesrRequest);

            if (response)
            {
                

                ErrorMessage = String.Empty;

                TempData["SuccessMessage"]  = "Registration done sucessfully";

                return RedirectToPage("/Login");
            }

            ErrorMessage = "Registartion failed";

            return Page();

        }
    }
}
