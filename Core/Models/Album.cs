using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Album : BaseEntity
    {
        public string Title { get; set; }
        public string ImgUrl { get; set; } = string.Empty;
        public Guid AuthorId { get; set; }
        public User Author { get; set; }
        public ICollection<Picture> Pictures { get; set; }
    }
}
