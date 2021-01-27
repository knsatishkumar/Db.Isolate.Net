using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db.Isolate
{
    public sealed class CrudOperationSingletonService
    {
        private static readonly CrudOperationSingletonService instance = new CrudOperationSingletonService();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static CrudOperationSingletonService()
        {
        }

        private CrudOperationSingletonService()
        {
        }      

        public static CrudOperationSingletonService Instance
        {
            get
            {
                return instance;
            }
        }
    }
}
