using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ElLIb.Domain.Entities
{
    public class Author
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        ICollection<Book> Books { get; set; }
    }
}
