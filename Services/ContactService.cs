using CMSystemWebApis.Dtos;
using CMSystemWebApis.Entities;
using CMSystemWebApis.Interfaces;

namespace CMSystemWebApis.Services
{
    public class ContactService(IContactRepositry contactRepositry) : IContactService
    {
        private readonly IContactRepositry _repository = contactRepositry;

        public async Task<IEnumerable<ContactReadDto>> GetAllContactsAsync()
        {
            var contacts = await _repository.GetAllAsync();
            return contacts.Select(c => new ContactReadDto
            {
                Id = c.Id,
                Name = c.Name,
                PhoneNumber = c.PhoneNumber,
                Email = c.EmailAddress,
                Addresses = c.Addresses.Select(a => new AddressDto
                {
                    City = a.City,
                    ZipCode = a.ZipCode,
                    Street = a.Street
                }).ToList()
            });
        }
        public async Task<ContactReadDto?> GetContactByIdAsync(int id)
        {
            var contact = await _repository.GetByIdAsync(id);
            if (contact is null) return null;
           return new ContactReadDto
            {
                Id = contact.Id,
                Name = contact.Name,
                Email = contact.EmailAddress,
                PhoneNumber = contact.PhoneNumber,
                Addresses = contact.Addresses.Select(a => new AddressDto
                {
                    Street = a.Street,
                    City = a.City,
                    ZipCode = a.ZipCode
                }).ToList()
            };
        }
  
        public async Task<ContactReadDto> CreateContactAsync(ContactCreateDto contactCreateDto)
        {
            var contact = new Contact
            {
                Name = contactCreateDto.Name,
                EmailAddress = contactCreateDto.Email,
                PhoneNumber = contactCreateDto.PhoneNumber,
                Addresses = contactCreateDto.Addresses.Select(a => new Address
                {
                    Street = a.Street,
                    ZipCode = a.ZipCode,
                    City = a.City
                }).ToList()
            };

            await _repository.AddAsync(contact);
            await _repository.SaveChangesAsync();
            return new ContactReadDto
            {
                Id = contact.Id,
                Name = contact.Name,
                Email = contact.EmailAddress,
                PhoneNumber = contact.PhoneNumber,
                Addresses = contact.Addresses.Select(a => new AddressDto
                {
                    Street = a.Street,
                    City = a.City,
                    ZipCode = a.ZipCode
                }).ToList()
            };
        }
        
      public async Task<IEnumerable<ContactReadDto>> GetPaginatedContactsAsync(int page, int pageSize)
        {
            var contacts = await _repository.GetAllAsync();
            var paginatedContacts = contacts
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(c => new ContactReadDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    PhoneNumber = c.PhoneNumber,
                    Email = c.EmailAddress,
                    Addresses = c.Addresses.Select(a => new AddressDto
                    {
                        City = a.City,
                        ZipCode = a.ZipCode,
                        Street = a.Street
                    }).ToList()
                });
            return paginatedContacts;
        }
       public async Task<bool> UpdateContactAsync(int id, ContactUpdateDto dto)
        {
            var contact = await _repository.GetByIdAsync(id);
            if(contact is null) return false;
            contact.PhoneNumber = dto.PhoneNumber;
            contact.Name = dto.Name;
            contact.EmailAddress = dto.Email;

            _repository.UpdateAsync(contact);
            await _repository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteContactAsync(int id)
        {
            var contact = await _repository.GetByIdAsync(id);
            if (contact is null) return false;
            _repository.DeleteAsync(contact);
            await _repository.SaveChangesAsync();
            return true;
        }
        }
}
