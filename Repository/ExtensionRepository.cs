using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tutorial.Models;
using Tutorial.Data;
using System.Linq;

namespace Tutorial.Repository
{
    public class ExtensionRepository
    {
        private readonly BookStoreContext _context = null;

        public ExtensionRepository(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<List<ExtensionModel>> GetLanguages()
        {
            return await _context.Extension.Select(x => new ExtensionModel()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description
            }).ToListAsync();
        }

    }
}
