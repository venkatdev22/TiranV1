using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using TiranV1.Models;

namespace TiranV1.Controllers
{
    public class CandidateController : ApiController
    {
        private TiranV1DBEntities db = new TiranV1DBEntities();

        // GET api/Candidate
        public IEnumerable<Candidate_Tbl> GetCandidate_Tbl()
        {
            return db.Candidate_Tbl.AsEnumerable();
        }

        // GET api/Candidate/5
        public Candidate_Tbl GetCandidate_Tbl(int id)
        {
            Candidate_Tbl candidate_tbl = db.Candidate_Tbl.Find(id);
            if (candidate_tbl == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return candidate_tbl;
        }

        // PUT api/Candidate/5
        public HttpResponseMessage PutCandidate_Tbl(int id, Candidate_Tbl candidate_tbl)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != candidate_tbl.CandidateID)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(candidate_tbl).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Candidate
        public HttpResponseMessage PostCandidate_Tbl(Candidate_Tbl candidate_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Candidate_Tbl.Add(candidate_tbl);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, candidate_tbl);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = candidate_tbl.CandidateID }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Candidate/5
        public HttpResponseMessage DeleteCandidate_Tbl(int id)
        {
            Candidate_Tbl candidate_tbl = db.Candidate_Tbl.Find(id);
            if (candidate_tbl == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Candidate_Tbl.Remove(candidate_tbl);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, candidate_tbl);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}