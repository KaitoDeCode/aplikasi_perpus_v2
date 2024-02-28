using belajar_layouting.Model;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace belajar_layouting.Controllers
{
    internal class KategoriController : BaseController
    {
        private Table<Kategori> kategori;
        public KategoriController() {
            this.kategori = db.Kategoris;
        }

        public List<Kategori> getAll()
        {
            return this.kategori.ToList();
        }

        public void store(String nama)
        {
            try
            {
                Kategori newKategori = new Kategori { 
                    nama = nama
                }; 
                this.kategori.InsertOnSubmit(newKategori);
                db.SubmitChanges();
                utils.message("success", "Berhasil Membuat Kategory");
            }catch (Exception ex)
            {
                utils.message("error", ex.Message);
            }
        }

        public void update(int id, String nama)
        {
            try
            {
                var data = this.db.Kategoris.FirstOrDefault(item => item.id == id);
                if (data is null)
                {
                    this.utils.message("error", "Kategori tidak ditemukan");
                }

                data.nama = nama;
                this.db.SubmitChanges();
                this.utils.message("success", "Berhasil memperbarui data");

            }catch (Exception ex)
            {
                this.utils.message("error", ex.Message);
            }
        }


    }
}
