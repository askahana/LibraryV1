﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Shared.Models.Dtos
{
    public class BookDto
    {
        public int Id { get; set; }

        [Required]
        public string Author { get; set; }
        [Required]
        public string Title { get; set; }
        //[JsonConverter(typeof(JsonStringEnumConverter))]
        public Genre Genre { get; set; }
        public int PublishedYear { get; set; }
        public string Description { get; set; }
        public bool IsAvailable { get; set; }

    }
}
