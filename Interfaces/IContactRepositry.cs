using CMSystemWebApis.Entities;

namespace CMSystemWebApis.Interfaces
{
    public interface IContactRepositry
    {
        Task<IEnumerable<Contact>> GetAllAsync();
        Task<Contact?> GetByIdAsync(int id);
        Task AddAsync(Contact contact);
        void UpdateAsync(Contact contact);
        void DeleteAsync(Contact contact);
        Task SaveChangesAsync();
       
    }
}
