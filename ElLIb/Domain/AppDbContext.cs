using ElLIb.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ElLIb.Domain
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<TextField> TextFields { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "8af10569-b018-4fe7-a380-7d6a14c70b74",
                Name = "admin",
                NormalizedName = "ADMIN"
            },
            new IdentityRole
            {
                Id = "5e84bf2c-585f-42dc-a868-73157016ec70",
                Name = "moderator",
                NormalizedName = "MODERATOR"
            });
            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "my@email.com",
                NormalizedEmail = "MY@EMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "superpassword"),
                SecurityStamp = string.Empty,
                CreateOn = DateTime.Now
            },
            new ApplicationUser
            {
                Id = "86d55f40-9544-4d92-aa24-cc5693a5fd96",
                UserName = "moderator",
                NormalizedUserName = "MODERATOR",
                Email = "moderator@email.com",
                NormalizedEmail = "MODERATOR@EMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "moderatorpassword"),
                SecurityStamp = string.Empty,
                CreateOn = DateTime.Now
            });
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "8af10569-b018-4fe7-a380-7d6a14c70b74",
                UserId = "3b62472e-4f66-49fa-a20f-e7685b9565d8"
            },
            new IdentityUserRole<string>
            {
                RoleId = "5e84bf2c-585f-42dc-a868-73157016ec70",
                UserId = "86d55f40-9544-4d92-aa24-cc5693a5fd96"
            });
            
            builder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("63dc8fa6-07ae-4391-8916-e057f71239ce"),
                CodeWord = "PageIndex",
                Title = "Главная"
            });
            builder.Entity<TextField>().HasData(new TextField 
            { 
                Id = new Guid("70bf165a-700a-4156-91c0-e83fce0a277f"),
                CodeWord = "PageBooks",
                Title = "Книги"
            });
            builder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("4aa76a4c-c59d-409a-84c1-06e6487a137a"),
                CodeWord = "PageContacts",
                Title = "Контакты"
            });
            builder.Entity<Book>().HasData(new Book
            {
                Id = new Guid("0d23f2ec-2b54-4dd9-b52b-b7c83a23dd0a"),
                Title = "Ересь Хоруса",
                SubTitle = "Там ересь была",
                IsBooking = false,
                Text = "Ваха 40к",
                TitleImagePath = "1655641005121914702.jpg",
                GenreName = "Хоррор",
                GenreId = new Guid("e4ac715f-a600-4d01-8a09-5439c7b689b3"),
                AuthorName = "Жафаров Ильнур Наильевич",
                AuthorId = new Guid("ff9b30ce-ad2e-48ce-b811-e45481b55043")
            });
            builder.Entity<Book>().HasData(new Book
            {
                Id = new Guid("b2566eb6-2108-46ad-bc5f-b3a660d60d1b"),
                Title = "Ересь Ангрона",
                SubTitle = "Там тоже была ересь",
                IsBooking = false,
                Text = "Ваха 40к",
                TitleImagePath = "1655641009118970804.jpg",
                GenreName = "Фэнтези",
                GenreId = new Guid("da589ab3-c70c-4d96-9ea9-867fedea69ff"),
                AuthorName = "Букин Генадий Валентинович",
                AuthorId = new Guid("c07ada61-d847-43eb-b2eb-8e32adcd64f4")
            });
            builder.Entity<Genre>().HasData(new Genre
            {
                Id = new Guid("da589ab3-c70c-4d96-9ea9-867fedea69ff"),
                Name = "Фэнтези"
            });
            builder.Entity<Genre>().HasData(new Genre
            {
                Id = new Guid("e4ac715f-a600-4d01-8a09-5439c7b689b3"),
                Name = "Хоррор"
            });
            
            builder.Entity<Genre>().HasData(new Genre
            {
                Id = new Guid("a24f8429-67e3-418a-a479-4059e19ca643"),
                Name = "Неизвестный жанр"
            });
            builder.Entity<Author>().HasData(new Author
            {
                Id = new Guid("c07ada61-d847-43eb-b2eb-8e32adcd64f4"),
                Name = "Букин Генадий Валентинович"
            });
            builder.Entity<Author>().HasData(new Author
            {
                Id = new Guid("ff9b30ce-ad2e-48ce-b811-e45481b55043"),
                Name = "Жафаров Ильнур Наильевич"
            });
            builder.Entity<Author>().HasData(new Author
            {
                Id = new Guid("0bf3eaaa-107f-434e-85bc-49653b07515a"),
                Name = "Неизвестный автор"
            });
        }
    }
}
