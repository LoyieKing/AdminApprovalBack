using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Service.Login
{
    public class UserInformation
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 用户账户名
        /// </summary>
        public string UserName { get; set; } = null!;

        public DateTime LoginTime { get; set; }

        [JsonIgnore]
        public bool IsAdmin { get => UserName == "admin"; }
    }
}
