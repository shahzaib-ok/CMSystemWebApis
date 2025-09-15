using CMSystemWebApis.Dtos;

namespace CMSystemWebApis.Interfaces
{
    public interface IContactService
    {
        Task <IEnumerable<ContactReadDto>> GetAllContactsAsync();
        Task<ContactReadDto?> GetContactByIdAsync(int id);
        Task<ContactReadDto> CreateContactAsync(ContactCreateDto contactCreateDto);
        Task<IEnumerable<ContactReadDto>> GetPaginatedContactsAsync(int page, int pageSize);
        Task<bool> UpdateContactAsync(int id, ContactUpdateDto contactUpdateDto);
        Task<bool> DeleteContactAsync(int id);
     }
}
