using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Model.Models
{

    [Table("Authors")]
    public class Fluent_Author
    {
        [Key]
        public int Author_Id { get; set; }
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }
        public string Location { get; set; }
        [NotMapped]
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
        //public List<Fluent_Book> Books { get; set; }

        public  List<Fluent_BookAuthorMap> BookAuthorMaps { get; set; }
    }
}
