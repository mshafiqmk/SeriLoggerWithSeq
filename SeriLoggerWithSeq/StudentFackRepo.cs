using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriLoggerWithSeq
{
    public class StudentFackRepo
    {
        public static IList<Student> GetStudentList()
        {
            var list = new List<Student>();
            list.Add(new Student() { Name = "shafiq", Age="22" });
            list.Add(new Student() { Name = "adnan", Age="8" });
            list.Add(new Student() { Name = "Muhammad", Age="29" });
            list.Add(new Student() { Name = "Abubakar", Age="25" });
            list.Add(new Student() { Name = "Umer", Age="26" });
            list.Add(new Student() { Name = "Usman", Age="27" });
            list.Add(new Student() { Name = "Ali", Age="28" });
            return list;
        }
    }
}
