using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NoteManagementPortal.Pages
{
    public class UpdateProfileModel : PageModel
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
                TempData["StatusMessage"] = "Profile Updated";
            }
            else
            {
                TempData["StatusMessage"] = "Profile Updated failed";
            }

            return RedirectToPage("/Notes");
        }
    }
}
