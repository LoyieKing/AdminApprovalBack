using Data.Entity.SystemManage;
using Data.Infrastructure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminApprovalBack.Models
{
    public class TreeModel<T> where T : IEntity<T>, ITreeEntity
    {
        [JsonProperty("data")]
        public T Data { get; set; }

        [JsonProperty("children")]
        public List<TreeModel<T>> Children { get; set; } = new List<TreeModel<T>>();

        public TreeModel(T data)
        {
            Data = data;
        }
    }

    public class TreeModel<TData, TChildren>
        where TData : IEntity<TData>, ITreeEntity
        where TChildren : IEntity<TChildren>, ITreeEntity
    {
        [JsonProperty("data")]
        public TData Data { get; set; }

        [JsonProperty("children")]
        public List<TreeModel<TChildren>> Children { get; set; } = new List<TreeModel<TChildren>>();

        public TreeModel(TData data)
        {
            Data = data;
        }
    }

    public static class TreeModelExtension
    {
        public static IEnumerable<TreeModel<T>> ToTreeModel<T>(this IEnumerable<T> data) where T : IEntity<T>, ITreeEntity
        {
            var idMap = data.Select(it => new TreeModel<T>(it)).ToDictionary(it => it.Data.F_Id);
            foreach (var kv in idMap)
            {
                if (idMap.TryGetValue(kv.Value.Data.F_ParentId, out var parent))
                {
                    parent.Children.Add(kv.Value);
                }
            }
            var treeList = idMap.Where(it => !idMap.ContainsKey(it.Value.Data.F_ParentId)).Select(it => it.Value);
            return treeList;
        }
    }
}
