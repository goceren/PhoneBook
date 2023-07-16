using System.ComponentModel.DataAnnotations;

namespace PhoneBook.Data.Entities.Dto.Book
{
    public class UpdateBookDto
    {
        [Required]
        public Guid UUID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Company { get; set; }
    }
}
