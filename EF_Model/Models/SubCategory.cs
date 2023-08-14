using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Model.Models
{
    [Table("SubCategories")]
    public class SubCategory
    {
        [Key]
        public string SubCategory_Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
    }
}
