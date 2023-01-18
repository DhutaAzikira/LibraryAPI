using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models
{
    public class Buku
    {
        
        public int Id { get; set; }
        public string? Nama_buku { get; set; }
        public string? Kategori_buku { get; set; }
        public string? Penulis_buku { get; set; }
        public string? Gambar_buku { get; set; }
        public int? Tahun_buku { get; set; }
        public string? Penerbit_buku { get; set; }
        public string? File_buku { get; set; }
        

    }
}
