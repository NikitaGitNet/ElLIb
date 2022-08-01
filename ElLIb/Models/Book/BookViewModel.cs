using ElLIb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ElLIb.Models.Book
{
    public class BookViewModel
    {
        public Guid BookId { get; set; }
        [Required(ErrorMessage = "Заполните название книги")]
        [Display(Name = "Название книги")]
        public string Title { get; set; }
        [Display(Name = "Краткое описание книги")]
        public string SubTitle { get; set; }
        [Display(Name = "Полное описание книги")]
        public string TitleImagePath { get; set; }
        public string Text { get; set; }
        public int BooksCount { get; set; }
    }
}
