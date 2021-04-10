using Data.Entity.Approval;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminApprovalBack.Models
{
    public class InfoClassModel : IModel<InfoClassModel, InfoClassEntity>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Category { get; set; }
        public int ExpiredDays { get; set; }
        public string InputType { get; set; }
        public bool Reusable { get; set; }
    }
}