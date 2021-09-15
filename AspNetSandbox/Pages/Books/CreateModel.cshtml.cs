using System.Threading.Tasks;
using AspNetSandbox.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;

namespace AspNetSandbox.Pages.Shared
{
    /// <summary>Creates new books to add to our data.</summary>
    public class CreateModel : PageModel
    {
        private readonly AspNetSandbox.Data.ApplicationDbContext context;
        private readonly IHubContext<MessageHub> hubContext;
        private readonly IMapper mapper;

        public CreateModel(AspNetSandbox.Data.ApplicationDbContext context, IHubContext<MessageHub> hubContext, IMapper mapper)
        {
            this.context = context;
            this.hubContext = hubContext;
            this.mapper = mapper;
        }

        [BindProperty]
        public Book Book { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Book book = mapper.Map<Book>(Book);
            context.Book.Add(book);
            await hubContext.Clients.All.SendAsync("AddedBook", Book);

            await this.context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
