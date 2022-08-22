using System;
using System.ComponentModel.DataAnnotations;

namespace ElLIb.Models.Comment
{
    public class AddCommentModel
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public Guid BookId { get; set; }
        public string UserEmail { get; set; }
    }
}
