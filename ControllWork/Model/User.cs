using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class User
    {
        public long Id { get; set; }
        public long Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
