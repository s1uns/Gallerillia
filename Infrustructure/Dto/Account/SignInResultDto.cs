using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustructure.Dto.Account
{
    public class SignInResultDto
    {
        public Guid UserId { get; set; }
        public string Bearer { get; set; }
    }
}