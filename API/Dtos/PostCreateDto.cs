using System;

namespace API.Dtos
{
    public class PostCreateDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Created {get; set;}
        public string Photo { get; set; }

    }
}