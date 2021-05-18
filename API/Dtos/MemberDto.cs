using System;
using System.Collections.Generic;
using API.Entities;

namespace API.Dtos
{
    public class MemberDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public string  City { get; set; }
        public string Country { get; set; }
        public string Image { get; set; }
        public ICollection<PostDto> Posts { get; set; }

    }
}