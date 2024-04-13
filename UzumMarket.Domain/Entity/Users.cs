using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UzumMarket.Domain.Common;

namespace UzumMarket.Domain.Entity
{
    public class Users : Auditable
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
