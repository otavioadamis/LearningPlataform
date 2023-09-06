using LearningPlataform.Dal.Data;
using LearningPlataform.Domain.Interfaces;
using LearningPlataform.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningPlataform.Dal
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly AppDbContext _dbContext;

        public EnrollmentRepository(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        // Save changes (?)
        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        // Create
        public Enrollment Add(Enrollment thisEnrollment)
        {
            _dbContext.Enrollments.Add(thisEnrollment);
            return thisEnrollment;
        }

        // Read
        public List<Enrollment> Get()
        {
            var allEnrollments = _dbContext.Enrollments.ToList();
            return allEnrollments;
        }

        public Enrollment GetById(string _id)
        {
            var enrollment = _dbContext.Enrollments.FirstOrDefault(x => x.Id == _id);
            return enrollment;
        }

        // Delete
        public void Delete(string _id)
        {
            var enrollment = _dbContext.Enrollments.FirstOrDefault(x => x.Id == _id);
            _dbContext.Enrollments.Remove(enrollment);
        }
    }
}
