using LibraryAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AkunController : ControllerBase
    {
        private static List<Akun> Akun = new List<Akun>()
        {

        };
        private readonly LibraryContext _context;
        public AkunController(LibraryContext context)
        {
            _context = context;
        }
        // GET: api/<AkunController>
        [HttpGet]
        public async Task<ActionResult<List<Buku>>> get()
        {
            return Ok(await _context.Akuns.ToListAsync());
        }

        // GET api/<AkunController>/5
        [HttpGet("{id}")]

        public async Task<ActionResult<List<Akun>>> get(int id)
        {
            var Akun = await _context.Akuns.FindAsync(id);
            if (Akun == null)
            {
                return BadRequest("Buku Tidak Ditemukan");
            }
            return Ok(Akun);
        }

        // POST api/<AkunController>
        [HttpPost]

        public async Task<ActionResult<List<Akun>>> TambahAkun(Akun TambahAkun)
        {

            //_context.Database.ExecuteSqlRaw("DBCC CHECKIDENT('librarydb.dbo.bukus', RESEED, {0})", );
            _context.Akuns.Add(TambahAkun);
            _context.Database.ExecuteSql($"DBCC CHECKIDENT([dbo.bukus], RESEED, 0)");
            _context.Database.ExecuteSql($"DBCC CHECKIDENT([dbo.bukus], RESEED)"); 
            await _context.SaveChangesAsync();


            return Ok(await _context.Akuns.ToListAsync());
        }

        // PUT api/<AkunController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Akun>>> UpdateAkun(Akun Update)
        {
            var akun = await _context.Akuns.FindAsync(Update.Id);
            if (akun == null)
            {
                return BadRequest("Buku Tidak Ditemukan");
            }
            akun.Username = Update.Username;
            akun.Password = Update.Password;
            akun.Nama_depan = Update.Nama_depan;
            akun.Nama_belakang = Update.Nama_belakang;

            await _context.SaveChangesAsync();
            return Ok(await _context.bukus.ToListAsync());
        }

        // DELETE api/<AkunController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Akun>>> DeleteAkun(int id)
        {
            var Akun = await _context.Akuns.FindAsync(id);
            if (Akun == null)
            {
                return BadRequest("Buku Tidak Ditemukan");
            }
            _context.Akuns.Remove(Akun);

            await _context.SaveChangesAsync();

            return Ok(await _context.Akuns.ToListAsync());
        }
    }
}
