using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Dtos
{
    public class BookUpdateDto
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public Genre Genre { get; set; }
        public int PublishedYear { get; set; }
        public string Description { get; set; }
        public bool IsAvailable { get; set; }
    }
}
