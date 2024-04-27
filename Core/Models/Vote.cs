using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Vote : BaseEntity
    {
        public bool IsPositive { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid PictureId { get; set; }
        public Picture Picture { get; set; }

    }
}
