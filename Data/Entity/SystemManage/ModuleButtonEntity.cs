
using System;
using Data.Infrastructure;

namespace Data.Entity.SystemManage
{
    public class ModuleButtonEntity : IEntity<ModuleButtonEntity>, ITreeEntity
    {
        public string F_ModuleId { get; set; }
        public string F_ParentId { get; set; }
        public int? F_Layers { get; set; }
        public string F_EnCode { get; set; }
        public string F_FullName { get; set; }
        public string F_Icon { get; set; }
        public int? F_Location { get; set; }
        public string F_JsEvent { get; set; }
        public string F_UrlAddress { get; set; }
        public bool? F_Split { get; set; }
        public bool? F_IsPublic { get; set; }
        public bool? F_AllowEdit { get; set; }
        public bool? F_AllowDelete { get; set; }
        public int? F_SortCode { get; set; }
        public bool? F_EnabledMark { get; set; }
        public string F_Description { get; set; }
    }
}
