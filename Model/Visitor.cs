using Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class Visitor : Base
    {
        public string Name { get; set; }
        public int? IdImages { get; set; }
        [ForeignKey("IdImages")]
        public Images Images { get; set; }
    }
}
