using static PhoneBook.Data.Core.Enum.Enums;
using System.ComponentModel.DataAnnotations;

namespace PhoneBook.Data.Entities.Dto.BookContact
{
    public class UpdateBookContactDto
    {
        [Required]
        public Guid UUID { get; set; }
        [Required]
        public ContactTypeEnum Type { get; set; }
        [Required]
        public string Information { get; set; }
        [Required]
        public Guid BookUUID { get; set; }
    }
}
