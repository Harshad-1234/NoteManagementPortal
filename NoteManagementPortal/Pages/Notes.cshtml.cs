using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using NoteManagementPortal.Models;
using NoteManagementPortal.Service.Interface;
using System.Net.Http.Json;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml;

namespace NoteManagementPortal.Pages
{
    public class NotesModel : PageModel
    {
        private readonly IAPIService _apiService;
        private readonly IConfiguration _configuration;

        public NotesModel(IAPIService apiService, IConfiguration configuration)
        {
            _apiService = apiService;
            _configuration = configuration;
        }

        [BindProperty]
        public GetAllNotesByUserIdResponse NotesResponse { get; set; }

        [BindProperty]
        public UesrProfileResponse uesrProfileResponse { get; set; }



        public async Task<ActionResult> OnGetAsync()
        {
            if (TempData.ContainsKey("StatusMessage"))
            {
                ViewData["StatusMessage"] = TempData["StatusMessage"].ToString();
            }

            
            string userJson = HttpContext.Session.GetString("CurrentUser");

            if (String.IsNullOrEmpty(userJson))
            {
                return RedirectToPage("/Login");
            }
               
            User currentUser = JsonSerializer.Deserialize<User>(userJson);

            NotesResponse = await _apiService.GetAllNotesByUserId(currentUser.UserId, currentUser.Token);

            uesrProfileResponse = await _apiService.GetUserProfile(currentUser.UserId, currentUser.Token);


            if (!TempData.ContainsKey("UserName"))
            {
                TempData["UserName"] = currentUser.UserName;
            }


            return Page();
        }
    }
}
