using H_Spot.Models;
using HPlusSport.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

                                            //Pythagoras Dokpesi BU/23C/IT/8941
namespace HPlusSport.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalsController : ControllerBase
    {
        private readonly TypeContext _context;

        public MedicalsController(TypeContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        [HttpGet]
        public IEnumerable<Illnesses> GetIllness()
        {
            return _context.Illness.Include(i => i.Symptoms).ToArray();
        }

        [HttpPost]
        public async Task<ActionResult<Illnesses>> PostIllnesses(Illnesses illness)
        {
            // Ensures Symptoms is not null
            illness.Symptoms = illness.Symptoms ?? new List<Symptom>();

            _context.Illness.Add(illness);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                "GetIllness",
                new { id = illness.Id },
                illness);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Illnesses>> DeleteIllness(int id)
        {
            var illness = await _context.Illness.FindAsync(id);
            if (illness == null)
            {
                return NotFound();
            }

            _context.Illness.Remove(illness);
            await _context.SaveChangesAsync();

            return illness;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutIllness(int id, Illnesses illness)
        {
            if (id != illness.Id)
            {
                return BadRequest();
            }

            _context.Entry(illness).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Illness.Any(i => i.Id == id))
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

        [HttpGet("symptoms")]
        public IEnumerable<Symptom> GetSymptoms()
        {
            return _context.Symptoms.ToArray();
        }

        [HttpPost("symptoms")]
        public async Task<ActionResult<Symptom>> PostSymptom(Symptom symptom)
        {
            _context.Symptoms.Add(symptom);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                "GetSymptoms",
                new { id = symptom.Id },
                symptom);
        }

        [HttpDelete("symptoms/{id}")]
        public async Task<ActionResult<Symptom>> DeleteSymptom(int id)
        {
            var symptom = await _context.Symptoms.FindAsync(id);
            if (symptom == null)
            {
                return NotFound();
            }

            _context.Symptoms.Remove(symptom);
            await _context.SaveChangesAsync();

            return symptom;
        }

        [HttpPut("symptoms/{id}")]
        public async Task<ActionResult> PutSymptom(int id, Symptom symptom)
        {
            if (id != symptom.Id)
            {
                return BadRequest();
            }

            _context.Entry(symptom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Symptoms.Any(s => s.Id == id))
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
    }
}
