using belajar_layouting.Model;
using belajar_layouting.utils;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace belajar_layouting.Controllers
{
    internal class PeminjamController
    {
        private DataClassesDataContext db;
        private Utilities utils;
        public PeminjamController() {
            this.db       = new DataClassesDataContext();
            this.utils = new Utilities();
        }

        public void store(String nama, String email, String noTelp, String alamat)
        {
            try
            {
                peminjam newPeminjam = new peminjam
                {
                    nama = nama,
                    email = email,
                    noTelp = noTelp,
                    alamat = alamat,
                };
                this.db.peminjams.InsertOnSubmit(newPeminjam);
                this.db.SubmitChanges();
                this.utils.message("success", "Data peminjam berhasil ditambahkan");
            }
            catch (Exception ex)
            {
                this.utils.message("error", ex.Message);
            }
        }

        public void update(int id,String nama,String email, String noTelp, String alamat)
        {
            try
            {
                var peminjam = this.db.peminjams.FirstOrDefault(i=> i.id == id);
                if (peminjam == null)
                {
                    this.utils.message("Success","Peminjam tidak ditemukan");
                }
                peminjam.nama = nama;
                peminjam.email = email;
                peminjam.noTelp = noTelp;
                peminjam.alamat = alamat;
                this.db.SubmitChanges();
                this.utils.message("success","Berhasil memperbarui peminjam");
            }catch (Exception ex)
            {
                this.utils.message("error", ex.Message);
            }
        }
    }
}
