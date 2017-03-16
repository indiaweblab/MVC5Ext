using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.WCF
{
    public class Employee
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Department { get; set; }

        public string Grade { get; set; }

        public override string ToString()
        {
            return string.Format("ID: {0,-5}姓名: {1, -5}级别: {2, -4} 部门: {3}", Id, Name, Grade, Department);
        }
    }
}
