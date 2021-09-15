using System.Linq;
using System.Threading.Tasks;
using AspNetSandbox.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace AspNetSandbox.Pages.Shared
{
    /// <summary>Provides the ability to edit book data.</summary>
    public class EditModel : PageModel
    {
        private readonly AspNetSandbox.Data.ApplicationDbContext context;
        private readonly IHubContext<MessageHub> hubContext;
        private readonly IMapper mapper;

        public EditModel(AspNetSandbox.Data.ApplicationDbContext context, IHubContext<MessageHub> hubContext, IMapper mapper)
        {
            this.context = context;
            this.hubContext = hubContext;
            this.mapper = mapper;
        }

        [BindProperty]
        public Book Book { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book = await this.context.Book.FirstOrDefaultAsync(m => m.Id == id);

            if (Book == null)
            {
                return NotFound();
            }

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Book book = mapper.Map<Book>(Book);
            context.Book.Add(book);
            await hubContext.Clients.All.SendAsync("EditedBook", Book);
            this.context.Attach(Book).State = EntityState.Modified;

            try
            {
                await this.context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(Book.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BookExists(int id)
        {
            return this.context.Book.Any(e => e.Id == id);
        }
    }
}
