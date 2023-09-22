using advice_generator_app_api.Models;

namespace advice_generator_app_api.Interfaces
{
    public interface IAdviceItemRepository
    {
        ICollection<AdviceItem> GetAdviceItems();
        //AdviceItem GetAdviceItem(int id);
        AdviceItem GetAdviceItem(string name);
        //bool AdviceItemExists(int id);
        bool AdviceItemExists(string id);
    }
}
