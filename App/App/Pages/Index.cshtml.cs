using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.Pages;

[Authorize]
public class IndexModel : PageModel
{
    public IndexModel()
    {
    }
}
