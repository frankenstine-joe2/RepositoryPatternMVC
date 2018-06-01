using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Web.Models;

namespace DAL.Models
{
    public class StudentRepository : GenericRepository<ApplicationDbContext, Student>, IStudentRepository
    {
        Student IStudentRepository.GetStudentByGrade(int grade)
        {
            return new Student()
            {
                Id = 10,
                Address = "Planet Triclo",
                Name = "John Doe"
            };
        }
    }
}
