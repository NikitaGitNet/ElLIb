﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}
