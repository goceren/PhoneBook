using System.ComponentModel.DataAnnotations;
using static PhoneBook.Web.Core.Enum.Enums;

namespace PhoneBook.Web.Entities.Dto.BookContact
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
