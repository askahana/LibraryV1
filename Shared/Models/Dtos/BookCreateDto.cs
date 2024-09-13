using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Shared.Models.Dtos
{
    public class BookCreateDto
    {
        public string Author { get; set; }
        public string Title { get; set; }
        //[JsonConverter(typeof(JsonStringEnumConverter))]
        public Genre Genre { get; set; }
        public int PublishedYear { get; set; }
        public string Description { get; set; }
        public bool IsAvailable { get; set; }
    }
}
