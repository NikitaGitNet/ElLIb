using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElLIb.Domain.Entities
{
    public class Rating
    {
        public Guid Id { get; set; }
        public double RatingValue { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
        public Guid BookId { get; set; }
        [ForeignKey("BookId")]
        public Book Book { get; set; }
    }
}
