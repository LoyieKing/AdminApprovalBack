using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Infrastructure
{
    public interface ITreeEntity
    {
        string F_Id { get; set; }
        string F_ParentId { get; set; }
    }
}
