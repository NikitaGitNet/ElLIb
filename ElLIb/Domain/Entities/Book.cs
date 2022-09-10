using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElLIb.Domain.Entities
{
    public class Book : EntityBase
    {
        [Required(ErrorMessage = "Заполните название книги")]
        [Display(Name = "Название книги")]
        public override string Title { get; set; }
        [Display(Name = "Краткое описание книги")]
        public override string SubTitle { get; set; }
        [Display(Name = "Полное описание книги")]
        public bool IsBooking { get; set; }
        public override string Text { get; set; }
        [Display(Name = "Заполнить в формате - Фамилия Имя Отчество")]
        public string Author { get; set; }
        public string Genre { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}
