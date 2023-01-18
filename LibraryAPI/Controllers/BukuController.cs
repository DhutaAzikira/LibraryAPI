using LibraryAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BukuController : ControllerBase
    {
        private static List<Buku> IdBuku = new List<Buku>()
        {

        };
        private readonly LibraryContext _context;
        public BukuController(LibraryContext context)
        {
            _context = context;
        }

        // GET: api/<BukuController>
        [HttpGet]
        public async Task<ActionResult<List<Buku>>> get()
        {
            return Ok(await _context.bukus.ToListAsync());
        }

        // GET api/<BukuController>/5

        [HttpGet("{id}")]

        public async Task<ActionResult<List<Buku>>> get(int id)
        {
            var buku = await _context.bukus.FindAsync(id);
            if (buku == null)
            {
                return BadRequest("Buku Tidak Ditemukan");
            }
            return Ok(buku);
        }

        [HttpGet("{Kategori}")]
        public ActionResult<List<Buku>> get(string Kategori)
        {
            var buku = _context.bukus.Where(b => b.Kategori_buku == Kategori);
            if (buku == null)
            {
                return BadRequest("Buku Tidak Ditemukan");
            }
            return Ok(buku);
        }

        // POST api/<BukuController>
        [HttpPost]

        public async Task<ActionResult<List<Buku>>> AddBuku(Buku TambahBuku)
        {

            //_context.Database.ExecuteSqlRaw("DBCC CHECKIDENT('librarydb.dbo.bukus', RESEED, {0})", );
            _context.bukus.Add(TambahBuku);
            _context.Database.ExecuteSql($"DBCC CHECKIDENT([dbo.bukus], RESEED, 0)");
            _context.Database.ExecuteSql($"DBCC CHECKIDENT([dbo.bukus], RESEED)");
            await _context.SaveChangesAsync();


            return Ok(await _context.bukus.ToListAsync());
        }

        // PUT api/<BukuController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Buku>>> UpdateBuku(Buku Update)
        {
            var buku = await _context.bukus.FindAsync(Update.Id);
            if (buku == null)
            {
                return BadRequest("Buku Tidak Ditemukan");
            }
            buku.Nama_buku = Update.Nama_buku;
            buku.Tahun_buku = Update.Tahun_buku;
            buku.Penulis_buku = Update.Penulis_buku;
            buku.Kategori_buku = Update.Kategori_buku;

            await _context.SaveChangesAsync();
            return Ok(await _context.bukus.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Buku>>> DeleteBuku(int id)
        {
            var buku = await _context.bukus.FindAsync(id);
            if (buku == null)
            {
                return BadRequest("Buku Tidak Ditemukan");
            }
            _context.bukus.Remove(buku);
            
            await _context.SaveChangesAsync();

            return Ok(await _context.bukus.ToListAsync());
        }
    }


}