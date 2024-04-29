using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NoteManagementPortal.Models;
using NoteManagementPortal.Service.Interface;
using System.Text.Json;

namespace NoteManagementPortal.Pages
{
    public class DeleteNoteModel : PageModel
    {
        private readonly IAPIService _apiService;


        public DeleteNoteModel(IAPIService apiService)
        {
            _apiService = apiService;
        }

  
        public IActionResult OnGet(int id,string Title)
        {
            string userJson = HttpContext.Session.GetString("CurrentUser");

            User currentUser = JsonSerializer.Deserialize<User>(userJson);

            var IsDeleted =  _apiService.DeleteNote(id, currentUser.UserId, currentUser.Token);

            if (IsDeleted.Result)
            {
                TempData["StatusMessage"] = "Deleted Note - "+Title;
            }
            else
            {
                TempData["StatusMessage"] = "Delete operation failed";
            }

            return RedirectToPage("/Notes");
        }
    }
}
