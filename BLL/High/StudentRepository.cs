using IBLL.High;
using Model.High;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.High
{
    public class StudentRepository : IStudentRepository
    {
        IEnumerable<Student> IStudentRepository.GetAll()
        {
            throw new NotImplementedException();
        }

        Student IStudentRepository.Get(int id)
        {
            throw new NotImplementedException();
        }

        Student IStudentRepository.Add(Student item)
        {
            return new Student {
                 Id = 1,
                  Graduation = "2",
                  Major = "123"
            };
        }

        bool IStudentRepository.Update(Student item)
        {
            throw new NotImplementedException();
        }

        bool IStudentRepository.Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
