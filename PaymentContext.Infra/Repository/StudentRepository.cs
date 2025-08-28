using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Repositories;
using PaymentContext.Infra.Data;

namespace PaymentContext.Infra.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public void CreateSubscription(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();

        }

        public bool DocumentExists(string document)
        {
            _context.Students.Any(s => s.Document.Number == document);
            return false;
        }

        public bool EmailSExists(string email)
        {
            _context.Students.Any(s => s.Email.Address == email);
            return false;
        }
    }
}