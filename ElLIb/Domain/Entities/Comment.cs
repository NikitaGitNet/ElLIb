using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElLIb.Domain.Entities
{
    public class Comment
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Text { get; set; }
        public DateTime? CreateOn { get; set; }
        public string UserEmail { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
        public Guid BookId { get; set; }
        [ForeignKey("Id")]
        public Book Book { get; set; }
    }
}
