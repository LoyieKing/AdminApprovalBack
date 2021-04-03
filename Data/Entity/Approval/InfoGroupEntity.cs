using Data.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entity.Approval
{
    public class InfoGroupEntity : IEntity
    {
        public string Name { get; set; }
        public List<InfoGroupItemEntity> Items { get; set; }
    }

    class InfoGroupMap : EntityTypeConfiguration<InfoGroupItemEntity>
    {
    }
}
