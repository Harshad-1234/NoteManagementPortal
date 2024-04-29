using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NoteManagementPortal.Pages
{
    public class ChangePasswordModel : PageModel
    {
        public async Task<ActionResult> OnGet(string IsUpdated)
        {
            bool isUpdatedValue = false;

            if (!string.IsNullOrEmpty(IsUpdated) && bool.TryParse(IsUpdated, out bool parsedValue))
            {
                isUpdatedValue = parsedValue;
            }


            if (isUpdatedValue)
            {
                TempData["StatusMessage"] = "Password has changed succesfully";
            }
            else
            {
                TempData["StatusMessage"] = "Password updation failed";
            }

            return RedirectToPage("/Notes");
        }
    }
}
