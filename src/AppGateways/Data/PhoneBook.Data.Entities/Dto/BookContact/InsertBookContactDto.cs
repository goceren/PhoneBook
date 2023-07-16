using System.ComponentModel.DataAnnotations;

namespace PhoneBook.Data.Entities.Dto.BookContact
{
    public class InsertBookContactDto
    {
        
        [Required]
        public Core.Enum.Enums.ContactTypeEnum Type { get; set; }
        [Required]
        public string Information { get; set; }
        [Required]
        public Guid BookUUID { get; set; }
    }
}
