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
        private Table<peminjam> peminjam;
        private DataClassesDataContext db;
        private Utilities utils;
        public PeminjamController() {
            this.peminjam = new DataClassesDataContext().peminjams;
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
                this.peminjam.InsertOnSubmit(newPeminjam);
                this.db.SubmitChanges();
                this.utils.message("success", "Data peminjam berhasil ditambahkan");
            }
            catch (Exception ex)
            {
                this.utils.message("error", ex.Message);
            }
        }
    }
}
