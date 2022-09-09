using ElLIb.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ElLIb.Areas.Admin.Models
{
    public class BookViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Заполните название книги")]
        [Display(Name = "Название книги")]
        public string Title { get; set; }
        [Display(Name = "Краткое описание книги")]
        public string SubTitle { get; set; }
        [Display(Name = "Полное описание книги")]
        public bool IsBooking { get; set; }
        public virtual string TitleImagePath { get; set; }
        [Display(Name = "SEO метатег Title")]
        public string MetaTitle { get; set; }
        [Display(Name = "SEO метатег Description")]
        public string MetaDescription { get; set; }
        [Display(Name = "SEO метатег Keywords")]
        public string MetaKeywords { get; set; }
        [DataType(DataType.Time)]
        public DateTime DateAdded { get; set; }
        public string Text { get; set; }
        public IQueryable<Genre> Genres { get; set; }
        public IQueryable<Author> Authors { get; set; }
    }
}