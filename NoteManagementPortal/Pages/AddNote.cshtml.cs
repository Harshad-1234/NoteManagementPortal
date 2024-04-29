using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NoteManagementPortal.Pages
{
    public class AddNoteModel : PageModel
    {
        public async Task<ActionResult> OnGet(string IsAdded,string Title)
        {
            bool isAddedValue = false;

            if (!string.IsNullOrEmpty(IsAdded) && bool.TryParse(IsAdded, out bool parsedValue))
            {
                isAddedValue = parsedValue;
            }


            if (isAddedValue)
            {
                TempData["StatusMessage"] = "Added New note - "+ Title;
            }
            else
            {
                TempData["StatusMessage"] = "Create operation failed";
            }

            return RedirectToPage("/Notes");
        }
    
}
}
