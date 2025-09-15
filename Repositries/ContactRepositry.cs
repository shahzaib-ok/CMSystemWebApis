using CMSystemWebApis.Data;
using CMSystemWebApis.Entities;
using CMSystemWebApis.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CMSystemWebApis.Repositries
{
    public class ContactRepositry(AppDbContext context) : IContactRepositry
    {
        private readonly AppDbContext _context = context;
        public async Task<IEnumerable<Contact>> GetAllAsync()
        {
            return await _context.Contacts.Include(c  =>c.Addresses).ToListAsync();
        }
        public async Task<Contact?> GetByIdAsync(int id)
        {
            return await _context.Contacts.Include(c => c.Addresses).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddAsync(Contact contact)
        {
            await _context.Contacts.AddAsync(contact);
        }
        public void UpdateAsync(Contact contact)
        {
           _context.Contacts.Update(contact);
        }
        public void DeleteAsync(Contact contact)
        {
            _context.Contacts.Remove(contact);
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
