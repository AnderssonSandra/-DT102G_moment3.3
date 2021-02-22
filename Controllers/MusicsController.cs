using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DT102G_moment3._3.Data;
using DT102G_moment3._3.Models;

namespace DT102G_moment3._3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicsController : ControllerBase
    {
        private readonly MusicContext _context;

        public MusicsController(MusicContext context)
        {
            _context = context;
        }

        // GET: api/Musics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Music>>> Getmusics()
        {
            return await _context.musics.ToListAsync();
        }

        // GET: api/Musics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Music>> GetMusic(int id)
        {
            var music = await _context.musics.FindAsync(id);

            if (music == null)
            {
                return NotFound();
            }

            return music;
        }

        // PUT: api/Musics/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMusic(int id, Music music)
        {
            if (id != music.MusicId)
            {
                return BadRequest();
            }

            _context.Entry(music).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MusicExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Musics
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Music>> PostMusic(Music music)
        {
            _context.musics.Add(music);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMusic", new { id = music.MusicId }, music);
        }

        // DELETE: api/Musics/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMusic(int id)
        {
            var music = await _context.musics.FindAsync(id);
            if (music == null)
            {
                return NotFound();
            }

            _context.musics.Remove(music);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MusicExists(int id)
        {
            return _context.musics.Any(e => e.MusicId == id);
        }
    }
}
