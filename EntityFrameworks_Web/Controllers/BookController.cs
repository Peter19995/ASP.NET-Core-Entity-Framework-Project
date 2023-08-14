using EF_DataAccess.Data;
using EF_Model.Models;
using EF_Model.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
namespace EntityFrameworks_Web.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _db;
        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Book> objList = _db.Books.Include(u => u.Publisher).Include(u=>u.BookAuthorMap).ThenInclude(u=>u.Author).ToList();
            //List<Book> objList = _db.Books.ToList();
            //foreach(var obj in objList)
            //{
            //    _db.Entry(obj).Reference(u => u.Publisher).Load();
            //    _db.Entry(obj).Collection(u => u.BookAuthorMap).Load();
            //    foreach (var bookAuht in obj.BookAuthorMap)
            //    {
            //        _db.Entry(bookAuht).Reference(u => u.Author).Load();
            //    }
            //}
            return View(objList);
        }

        public IActionResult Upsert(int? id)
        {
            BookVM obj = new();
            obj.PublisherList = _db.Publishers.Select(i => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Text = i.Name,
                Value = i.Publisher_Id.ToString()
            });
            if (id == null || id == 0)
            {
                return View(obj);
            }

            //edit
            obj.Book = _db.Books.FirstOrDefault(u => u.BookId == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(BookVM obj)
        {

            if (obj.Book.BookId == 0)
            {
                //create reaquest
                await _db.Books.AddAsync(obj.Book);
            }
            else
            {
                //update
                _db.Books.Update(obj.Book);
            }
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

            return View(obj);
        }

        public async Task<IActionResult> Delete(int id)
        {
            Book obj = new();

            obj = _db.Books.FirstOrDefault(u => u.BookId == id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Books.Remove(obj);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Details(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            BookDetail obj = new();
            //edit
            obj = _db.BookDetail.Include(u => u.Book).FirstOrDefault(u => u.Book_Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(BookDetail obj)
        {

            if (obj.BookDetail_Id == 0)
            {
                //create reaquest
                await _db.BookDetail.AddAsync(obj);
            }
            else
            {
                //update
                _db.BookDetail.Update(obj);
            }
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ManageAuthors(int id)
        {

            BookAuthorVm obj = new()
            {
                BookAuthorList = _db.BookAuthorMaps.Include(u => u.Author).Include(u => u.Book).Where(u => u.Book_Id == id).ToList(),
                BookAuthor = new()
                {
                    Book_Id = id
                },
                Book = _db.Books.FirstOrDefault(u => u.BookId == id)
            };
            List<int> tempListOfAssignedAuthors = obj.BookAuthorList.Select(u => u.Author_Id).ToList();
            //get all the author whos id is no in  the  tempListOfAssignedAuthors

            var tempList = _db.Authors.Where(u => !tempListOfAssignedAuthors.Contains(u.Author_Id)).ToList();
            obj.AuthorList = tempList.Select(i => new SelectListItem
            {
                Text = i.FullName,
                Value = i.Author_Id.ToString()
            });


            return View(obj);
        }

         
        [HttpPost]
        public IActionResult ManageAuthors(BookAuthorVm bookAuthorVm)
        { 
            if(bookAuthorVm.BookAuthor.Book_Id != 0 && bookAuthorVm.BookAuthor.Author_Id != 0)
            {
                _db.BookAuthorMaps.Add(bookAuthorVm.BookAuthor);
                _db.SaveChanges();
            }
            return RedirectToAction(nameof(ManageAuthors), new {@id = bookAuthorVm.BookAuthor.Book_Id});
        }


        [HttpPost]
        public IActionResult RemoveAuthors(int authorId, BookAuthorVm bookAuthorVm)
        {
            int bookId = bookAuthorVm.Book.BookId;
            BookAuthorMap bookAuthorMap = _db.BookAuthorMaps.FirstOrDefault(u => u.Author_Id == authorId && u.Book_Id == bookId);
           
            _db.BookAuthorMaps.Remove(bookAuthorMap);
            _db.SaveChanges();
            
            return RedirectToAction(nameof(ManageAuthors), new { @id = bookId });
        }


        public async Task<IActionResult> PlayGround(int id)
        {
            // var viewList = _db.MainBookDetails.ToList();
			//var viewList1 = _db.MainBookDetails.FirstOrDefault();
			//var viewList2 = _db.MainBookDetails.Where(u=>u.Price>30);
			//var viewList3 = _db.MainBookDetails.ToList();
            //updating  related data

   //         var bookRaw = _db.Books.FromSqlRaw("select * from books").ToList();
   //         var boobkid = 1;
			//var bookRaw1 = _db.Books.FromSqlRaw($"select * from books where bookid={boobkid}").ToList();


            var booksproc = _db.Books.FromSqlInterpolated($"Exec dbo.getBookDetailById {id}");

			//var bookdetail1 = _db.BookDetail.Include(b => b.Book).FirstOrDefault(b => b.BookDetail_Id == 5);
			//bookdetail1.NumberOfChapters = 2222;
			//bookdetail1.Book.Price = 2222;
			//_db.BookDetail.Update(bookdetail1);
			//_db.SaveChanges();


			//var bookdetail2 = _db.BookDetail.Include(b => b.Book).FirstOrDefault(b => b.BookDetail_Id == 5);
			//bookdetail2.NumberOfChapters = 1111;
			//bookdetail2.Book.Price = 1111;
			//_db.BookDetail.Attach(bookdetail2);
			//_db.SaveChanges();

			//IEnumerable<Book> BookList = _db.Books;
			//var FilteredBook1 = BookList.Where(b => b.Price > 50).ToList();


			//IQueryable<Book> BookList2 = _db.Books;
			//var FilteredBook2 = BookList2.Where(b => b.Price > 50).ToList();
			//var bookTemp = _db.Books.FirstOrDefault();
			//bookTemp.Price = 100;

			//var bookCollection = _db.Books;
			//decimal totalPrice = 0;

			//foreach (var book in bookCollection)
			//{
			//    totalPrice += book.Price;
			//}

			//var bookList = _db.Books.ToList();
			//foreach (var book in bookList)
			//{
			//    totalPrice += book.Price;
			//}

			//var bookCollection2 = _db.Books;
			//var bookCount1 = bookCollection2.Count();

			//var bookCount2 = _db.Books.Count();
			return RedirectToAction(nameof(Index));
        }


    }
}
