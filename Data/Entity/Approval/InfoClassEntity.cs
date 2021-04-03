using Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entity.Approval
{
    public class InfoClassEntity : IEntity
    {
        public string Name { get; set; } = null!;
        public int ExpiredMinutes { get; set; }
        public string Category { get; set; } = null!;
    }

    class InfoClassMap : EntityTypeConfiguration<InfoClassEntity>
    {

    }
}
