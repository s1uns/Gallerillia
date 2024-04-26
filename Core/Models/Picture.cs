using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Picture : BaseEntity
    {
        public string ImgUrl { get; set; }
        public Guid AlbumId { get; set; }
        public Album Album { get; set; }
        public ICollection<Vote> Votes { get; set; }

    }
}
