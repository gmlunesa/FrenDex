using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrenDex.Models
{
    public class Friend
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Unique]
        public string Nickname { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Likes { get; set; }
        public string Dislikes { get; set; }
        public string Favorites { get; set; }
        public string Hates { get; set; }
        public string Allergies { get; set; }
        [Ignore]
        public string FullName => $"{FirstName} {LastName}";
    }
}
