using belajar_layouting.Model;
using belajar_layouting.screen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace belajar_layouting.Controllers
{
    internal class BookController : BaseController
    {
        public List<Buku> getAll()
        {
            return db.Bukus.ToList();
        }
        public void store(String judul,int kode, int kategoriId, int penulisId)
        {
            try
            {
                Buku newBuku = new Buku
                {
                    judul = judul,
                    kode_buku = kode.ToString(),
                    kategori_id = kategoriId,
                    penulis_id = penulisId,
                };
                db.Bukus.InsertOnSubmit(newBuku);
                db.SubmitChanges();
                utils.message("success", "Behasil membuat buku");
            }catch (Exception ex)
            {
                utils.message("error", ex.Message);
            }
        }

        public void update(int id, String judul, int kode, int kategoriId, int penulisId)
        {
            try
            {
                var data = db.Bukus.FirstOrDefault(item => item.Id == id);
                if (data != null)
                {
                    utils.message("error", "Buku tidak ditemukan");
                }
                data.judul = judul;
                data.kode_buku = kode.ToString();
                data.kategori_id = kategoriId;
                data.penulis_id = penulisId;
                db.SubmitChanges();
                utils.message("success", "Berhasil memperbarui data");
            }catch(Exception ex)
            {
                utils.message("error",ex.Message);
            }
        }

        public void delete(int id)
        {
            try
            {
                var delete = db.Bukus.FirstOrDefault(item => item.Id == id);
                if (delete is null)
                {
                    utils.message("error", "Gagal menemukan data");
                }
                db.Bukus.DeleteOnSubmit(delete);
                db.SubmitChanges();
                utils.message("success", "Berhasil menghapus data");
            }catch (Exception ex)
            {
                utils.message("error", ex.Message);
            }
        }

    }
}
