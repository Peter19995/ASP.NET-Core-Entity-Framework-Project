﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Model.Models
{
    [Table("Categories")]
    public class Category
    {
        [Key ]
        public int Category_Id { get; set; }
        [Column("Name")]
        [Required]
        public string GenreName { get; set; }
       /// public int DisplayOrder { get; set; }
    }
}
