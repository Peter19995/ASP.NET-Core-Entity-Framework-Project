//// See https://aka.ms/new-console-template for more information
//using EF_DataAccess.Data;
//using EF_Model.Models;
//using Microsoft.EntityFrameworkCore;
//using static System.Reflection.Metadata.BlobBuilder;

Console.WriteLine("Hello, World!");
////using(ApplicationDbContext context = new ApplicationDbContext())
////{
////    context.Database.EnsureCreated();
////    if(context.Database.GetPendingMigrations().Count() >0)
////    {
////        context.Database.Migrate();
////    }
////}

////AddBooks();
////GetAllBooks();
////GetBook();

//void GetBook()
//{
//    try
//    {
//        using var context = new ApplicationDbContext();
//        var input = "Spider without Duty";
//        var books = context.Books.Skip(0).Take(2);
//        if (books != null)
//        {
//            //Console.WriteLine(books.Title + " - " + books.ISBN);
//            foreach (var book in books)
//            {
//                Console.WriteLine(book.Title + " - " + book.ISBN);
//            }
//        }
//        books = context.Books.Skip(4).Take(1);
//        if (books != null)
//        {
//            //Console.WriteLine(books.Title + " - " + books.ISBN);
//            foreach (var book in books)
//            {
//                Console.WriteLine(book.Title + " - " + book.ISBN);
//            }
//        }

//    }
//    catch (Exception e)
//    {

//    }
  
//}

//void GetAllBooks()
//{
//    using var context = new ApplicationDbContext();
//    var books = context.Books.ToList();
//    foreach (var book in books)
//    {
//        Console.WriteLine(book.Title + " - "+book.ISBN);
//    }
//}


//void AddBooks()
//{
//    Book book = new Book() { Title ="New EF Core Book", ISBN = "3445EEWWFF", Price = 10.93m,Publisher_Id = 1 }; 
//    using var context = new ApplicationDbContext();
//    var books = context.Books.Add(book);
//    context.SaveChanges();
//}

////UpdateBook();

//void UpdateBook()
//{
//    try
//    {
//        using var context = new ApplicationDbContext();
      
//        var books = context.Books.Where(u=>u.Publisher_Id == 1);
//        if (books != null)
//        {
//            foreach (var book in books)
//            {
//                book.Price = 55.55m;

//            }
//            context.SaveChanges();

//        }

//    }
//    catch (Exception e)
//    {

//    }
//}
//DeleteBook();

//void DeleteBook()
//{
//    using var context = new ApplicationDbContext();

//    var books = context.Books.Find(8);
//    if (books != null)
//    {
//        context.Remove(books);
//        context.SaveChanges();
//    }

//}