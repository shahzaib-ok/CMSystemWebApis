namespace CMSystemWebApis.Dtos
{
       public class ContactCreateDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public List<AddressDto> Addresses { get; set; }
    }
}
