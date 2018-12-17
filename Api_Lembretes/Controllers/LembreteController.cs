using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Api_Lembretes.Models;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Web.Http.Description;
using System.Web.Http.Cors;

namespace Api_Lembretes.Controllers
{
    public class LembreteController : ApiController
    {

        ModelLembrete db = new ModelLembrete();

        // GET: api/Lembrete
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        public async Task <IHttpActionResult> GetLembretes()
        {
            var lembretes = await (db.tb_Lembrete.ToListAsync());

            if (lembretes == null)
            {
                return BadRequest();
            }

            return Ok(lembretes);
        }

        // GET: api/Lembrete/5
        public async Task<IHttpActionResult> GetLembrete (int id)
        {
            var lembrete = await db.tb_Lembrete.Where(t => t.Id == id).FirstOrDefaultAsync();

            if (lembrete == null)
            {
                return NotFound();
            }

            return Ok(lembrete);
        }

        // POST: api/Lembrete
        public IHttpActionResult PostLembrete (tb_Lembrete lembrete)
        {
            try
            {
                db.Entry(lembrete).State = EntityState.Added;
                db.SaveChanges();

                return Created("", lembrete);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/Lembrete/5
        [HttpPut]
        public IHttpActionResult PutLembrete(tb_Lembrete lembrete)
        {
            try
            {
                db.Entry(lembrete).State = EntityState.Modified;
                db.SaveChanges();

                return Ok(lembrete);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        // DELETE: api/Lembrete/5
        [HttpDelete]
        [EnableCors(origins: "http://localhost:4200", headers:"*", methods:"*")]
        public IHttpActionResult DeleteLembrete(int id)
        {
            try
            {
                //var lembrete = db.tb_Lembrete.Where(tb => tb.Id == id).FirstOrDefault();
                var lembrete = db.tb_Lembrete.Find(id);

                db.tb_Lembrete.Remove(lembrete);
                db.SaveChanges();

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
