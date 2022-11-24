using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papara.Core.Entites
{
    public class User
    {
        
            public int id { get; set; }
           
            public int userId { get; set; }
           
            public string title { get; set; }
            public string body { get; set; }

    }
}
