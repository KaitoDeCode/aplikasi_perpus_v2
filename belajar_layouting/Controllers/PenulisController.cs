using belajar_layouting.Model;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace belajar_layouting.Controllers
{
    internal class PenulisController : BaseController
    {
        private Table<Penuli> penulis;
        public PenulisController() {
            this.penulis = db.Penulis;
        }

        public void store(String nama,String email)
        {
            try
            {
                Penuli newPenulis = new Penuli
                {
                    nama = nama, email = email
                };
                this.penulis.InsertOnSubmit(newPenulis);
                db.SubmitChanges();
                utils.message("success", "Berhasil membuat penulis");
            }
            catch (Exception ex)
            {
                utils.message("error", ex.Message);
            }
        }
    }
}
