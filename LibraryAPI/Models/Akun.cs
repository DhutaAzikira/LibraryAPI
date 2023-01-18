using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models
{
    public class Akun
    {
        
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Nama_depan { get; set; }
        public string? Nama_belakang { get; set; }
        
        

    }
}
