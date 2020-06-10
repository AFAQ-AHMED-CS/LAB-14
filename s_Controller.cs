using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CodeFirst.DAL;
using CodeFirst.Models;

namespace CodeFirst.Controllers{
    public class s_Controller : ApiController {
        private SchoolContext db = new SchoolContext();

        public IQueryable<Student> GetStudents(){
            return db.Students;
        }
		
        [ResponseType(typeof(Student))]
        public IHttpActionResult GetStudent(int id){
            Student student = db.Students.Find(id);
            if (student == null)
                return NotFound();

            return Ok(student);
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult PutStudent(int id, Student student){
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != student.ID)
                return BadRequest();

            db.Entry(student).State = EntityState.Modified;

            try{
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException){
                if (!StudentExists(id))
                    return NotFound();
                else
                    throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [ResponseType(typeof(Student))]
        public IHttpActionResult PostStudent(Student student){
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            db.Students.Add(student);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = student.ID }, student);
        }

        [ResponseType(typeof(Student))]
        public IHttpActionResult DeleteStudent(int id){
            Student student = db.Students.Find(id);
            if (student == null)
                return NotFound();

            db.Students.Remove(student);
            db.SaveChanges();

            return Ok(student);
        }

        protected override void Dispose(bool disposing){
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }

        private bool StudentExists(int id){
            return db.Students.Count(e => e.ID == id) > 0;
        }
    }
}