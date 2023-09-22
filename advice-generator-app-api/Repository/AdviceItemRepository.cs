using Microsoft.EntityFrameworkCore;
using advice_generator_app_api.Data;
using advice_generator_app_api.Interfaces;
using advice_generator_app_api.Models;

namespace advice_generator_app_api.Repository
{
    public class AdviceItemRepository : IAdviceItemRepository
    {
        private readonly AdviceItemContext _context;
        public AdviceItemRepository(AdviceItemContext context)
        {
            _context = context;
        }

        public ICollection<AdviceItem> GetAdviceItems()
        {
            return _context.AdviceItems.ToList();
        }

        /*public AdviceItem GetAdviceItem(int id)
        {
            return _context.AdviceItems.Where(item => item.Id == id).First();
        }*/

        public AdviceItem GetAdviceItem(string name)
        {
            return _context.AdviceItems.Where(item => item.Name == name).First();
        }

        /*public bool AdviceItemExists(int id)
        {
            return _context.AdviceItems.Any(item => item.Id == id);
        }*/

        public bool AdviceItemExists(string name)
        {
            return _context.AdviceItems.Any(item => item.Name == name);
        }
    }
}
