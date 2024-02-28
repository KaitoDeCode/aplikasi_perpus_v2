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
        public PenulisController() {
            
        }

        public List<Penuli> getAll()
        {
            return db.Penulis.ToList();
        }

        public void store(String nama,String email)
        {
            try
            {
                Penuli newPenulis = new Penuli
                {
                    nama = nama, email = email
                };
                db.Penulis.InsertOnSubmit(newPenulis);
                db.SubmitChanges();
                utils.message("success", "Berhasil membuat penulis");
            }
            catch (Exception ex)
            {
                utils.message("error", ex.Message);
            }
        }

        public void update(int id, String nama, String email)
        {
            try
            {
                var data = db.Penulis.FirstOrDefault(item => item.id == id);

                if(data is null)
                {
                    utils.message("error", "Gagal menemukan data");
                }

                data.nama = nama;
                data.email = email;
                db.SubmitChanges();
                utils.message("success", "Berhasil memperbarui data");

            }catch (Exception ex)
            {
                utils.message("error", ex.Message);
            }
        }

        public Penuli firstDefault(int id)
        {
            return db.Penulis.FirstOrDefault(i => i.id == id);
        }
    }
}
