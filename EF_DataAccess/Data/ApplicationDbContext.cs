using EF_DataAccess.FluentConfig;
using EF_Model.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {

		public DbSet<MainBookDetails> MainBookDetails { get; set; }
		public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookDetail> BookDetail { get; set; }

        //to rename to Fluent_BookDetails
        public DbSet<Fluent_BookDetail> BookDetail_fluent { get; set; }

        public DbSet<Fluent_Book> Fluent_Book { get; set; }
        public DbSet<Fluent_Publisher> Fluent_Publisher { get; set; }
        public DbSet<Fluent_Author> Fluent_Authors { get; set; }

        public DbSet<BookAuthorMap> BookAuthorMaps { get; set; }
        public DbSet<Fluent_BookAuthorMap> Fluent_BookAuthorMap { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=URND2;Database=EFDB;Trusted_Connection=False;TrustServerCertificate=True;MultipleActiveResultSets=true;User=sa;Password=Unistrat@1#;").LogTo(Console.WriteLine, new[] {DbLoggerCategory.Database.Command.Name},Microsoft.Extensions.Logging.LogLevel.Information );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Book>().Property(u => u.Price).HasPrecision(10, 5);
            modelBuilder.Entity<BookAuthorMap>().HasKey(u => new { u.Author_Id, u.Book_Id });
            modelBuilder.Entity<Fluent_BookAuthorMap>().HasKey(u => new { u.Author_Id, u.Book_Id });

            modelBuilder.ApplyConfiguration(new FluentAuthorConfig());
            modelBuilder.ApplyConfiguration(new FluentPublisherConfig());
            modelBuilder.ApplyConfiguration(new FluentBookAuthorMapConfig());
            modelBuilder.ApplyConfiguration(new FluentBookDetailConfig());
            modelBuilder.ApplyConfiguration(new FluentBookConfig());

            modelBuilder.Entity<BookAuthorMap>().HasKey(u => new { u.Author_Id, u.Book_Id });
            // add default Data
            modelBuilder.Entity<Book>().HasData(
                new Book { BookId = 1, Title = "Spider without Duty", ISBN = "123B12", Price = 10.99m, Publisher_Id = 1 },
                new Book { BookId = 2, Title = "Fortune Of Time", ISBN = "12S3B12", Price = 11.99m, Publisher_Id = 2 }
                );
            var bookList = new Book[]
            {
                new Book { BookId = 3, Title = "Fake Sunday", ISBN = "123L", Price = 20.99m,Publisher_Id = 3},
                new Book { BookId = 4, Title = "Cookie Jar", ISBN = "123M", Price = 25.99m ,Publisher_Id = 1},
                new Book { BookId = 5, Title = "Cloudy Forest", ISBN = "123Q", Price = 11.99m,Publisher_Id = 2 }
            };
            modelBuilder.Entity<Book>().HasData(bookList);

            modelBuilder.Entity<Publisher>().HasData(
                new Publisher { Publisher_Id = 1, Name = "Pub 1 Jimmy", Location = "Chicago" },
                new Publisher { Publisher_Id = 2, Name = "Pub 2 John", Location = "New York" },
                new Publisher { Publisher_Id = 3, Name = "Pub 3 Peter", Location = "Hawaii" }
                );

			modelBuilder.Entity<MainBookDetails>().HasNoKey().ToView("GetOnlyBookDetails");    

		}
    }
}
