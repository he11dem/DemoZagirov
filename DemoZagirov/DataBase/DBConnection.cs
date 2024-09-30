using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoZagirov.DataBase
{
    internal class DBConnection
    {
        public static Zaigirov420pEntities zaigirov = new Zaigirov420pEntities();

        public static Client loginedClient;

        public static Service selectedForEditService;
    }
}
