using System;
using System.Collections.Generic;

namespace StarWarsAPI.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Planet { get; set; }
        public string Gender { get; set; }
        public string Race { get; set; }
        public int Height { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public string Description { get; set; }
        public List<string> Movies { get; set; }

        public string CreatedById { get; set; }
        public ApplicationUser CreatedBy { get; set; }
    }
}