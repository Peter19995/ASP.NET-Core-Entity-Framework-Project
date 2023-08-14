using EF_Model.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EF_Model.ViewModels
{
    public class BookVM
    {
        public Book Book { get; set; }
        public IEnumerable<SelectListItem> PublisherList { get; set; }
    }
}
