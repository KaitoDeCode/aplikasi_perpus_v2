using belajar_layouting.Model;
using belajar_layouting.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace belajar_layouting.Controllers
{
    internal class BaseController
    {
        public DataClassesDataContext db;
        public Utilities utils;
        public BaseController() {
            this.db = new DataClassesDataContext();
            this.utils = new Utilities();
        }
    }
}
