using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Infrastructure
{
    public interface ITreeEntity
    {
        Guid Id { get; set; }
        Guid ParentId { get; set; }
    }
}
