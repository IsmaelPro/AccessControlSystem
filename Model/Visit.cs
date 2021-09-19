using Infra.Enums;
using Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Visit: Base
    {
        public int IdCompany { get; set; }
        [ForeignKey("IdCompany")]
        public Company Company { get; set; }
        public int IdVisitor { get; set; }
        [ForeignKey("IdVisitor")]
        public Visitor Visitor { get; set; }
        public EnumList.Status Status { get; set; }
        public bool IsClient { get; set; }
        public string Note { get; set; }
    }
}
