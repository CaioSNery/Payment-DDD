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

        public StudentQueriesTests()
        {
            for (var i = 0; i <= 10; i++)
            {
                _students.Add(new Student(
                new Name("Alunos", i.ToString())),
                new Document("00000000", i.ToString(), EDocumentType.CPF),
                new Email(i.ToString() + "@balta.io"));
            }
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