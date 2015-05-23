using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BaLogisticsSystem.Models.Common;

namespace BaLogisticsSystem.Models
{
    [Table("UserProfile")]
    public class UserProfileEntity : BaseEntity
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
    }
}
