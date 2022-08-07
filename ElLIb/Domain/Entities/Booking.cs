using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElLIb.Domain.Entities
{
    public class Booking
    {
        public Guid Id { get; set; }
        public DateTime CreateOn { get; set; }
        public DateTime FinishedOn { get; set; }
        public string UserEmail { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public Guid BookId { get; set; }
        [ForeignKey("BookId")]
        public int BooksCount { get; set; }
        public string BooksTitle { get; set; }
        public Book Book { get; set; }
        
    }
}
