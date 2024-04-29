using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NoteManagementPortal.Pages
{
    public class EditNoteModel : PageModel
    {
        public async Task<ActionResult> OnGet(string IsUpdated,string Title)
        {
            bool isUpdatedValue = false;

            if (!string.IsNullOrEmpty(IsUpdated) && bool.TryParse(IsUpdated, out bool parsedValue))
            {
                isUpdatedValue = parsedValue;
            }


            if (isUpdatedValue)
            {
                TempData["StatusMessage"] = "Updated note - "+Title;
            }
            else
            {
                TempData["StatusMessage"] = "Update operation failed";
            }

            return RedirectToPage("/Notes");
        }
    }
}
