using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class User : BaseEntity
    {
        public string Email { get; set; }
        public ICollection<Album> Albums { get; set; }
        public ICollection<Vote> Votes { get; set; }

    }
}
