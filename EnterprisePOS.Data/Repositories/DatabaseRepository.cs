using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterprisePOS.Data;
using EnterprisePOS.Data.Runtime;

namespace EnterprisePOS.Data.Repositories
{
    public class DatabaseRepository
    {
        public EnterprisePOSDataDataContext CreateContext()
        {
            return new EnterprisePOSDataDataContext(
                RuntimeConnectionStringProvider.GetOrDefault());
        }
    }
}
