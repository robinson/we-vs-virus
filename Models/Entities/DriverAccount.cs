using System.ComponentModel.DataAnnotations.Schema;

namespace WeVsVirus.Models.Entities
{
    public class DriverAccount : BaseEntity
    {
        public int Id { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        [NotMapped]
        public AccountType AccountType => AccountType.Driver;
    }
}
