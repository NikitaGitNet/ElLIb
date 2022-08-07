﻿using System;

namespace ElLIb.Models.Booking
{
    public class AddBookingModel
    {
        public Guid Id { get; set; }
        public DateTime CreateOn { get; set; }
        public DateTime FinishedOn { get; set; }
        public string UserEmail { get; set; }
        public string UserId { get; set; }
        public Guid BookId { get; set; }
        public string BookTitle { get; set; }
        public int BooksCount { get; set; }
    }
}
