using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Queries;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Testes.Queries
{
    [TestClass]
    public class StudentQueriesTests

    {
        private IList<Student> _students;

        public StudentQueriesTests(IList<Student> students)
        {
            _students = students;
        }

        [TestMethod]
        public void ReturnNullWhenDocumentIsValid()
        {
            var exp = StudentQueries.GetStudent("1234567895462");
            var student = _students.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreNotEqual(null, student);
        }


    }
}