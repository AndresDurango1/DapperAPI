﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Published { get; set; }
        public Guid AuthorId { get; set; }
        public Author Author { get; set; }

    }
}
