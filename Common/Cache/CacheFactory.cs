using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Cache
{
    public class CacheFactory
    {
        public static ICache Cache()
        {
            return new Cache();
        }

        private static ICache? instance;
        public static ICache Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Cache();
                }
                return instance;
            }
        }
    }
}
