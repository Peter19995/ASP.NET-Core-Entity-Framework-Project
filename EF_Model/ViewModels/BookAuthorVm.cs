using EF_Model.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Model.ViewModels
{
    public class BookAuthorVm
    {
        public BookAuthorMap BookAuthor { get; set; }
        public Book Book { get; set; }

        public IEnumerable<BookAuthorMap> BookAuthorList { get; set; }
        public IEnumerable<SelectListItem> AuthorList { get; set; }
    }
}
