using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._1
{
    internal class DBHandler
    {
        private string pathToDBFile;
        private int employeesCount;
        public int EmployeesCount
        {
            get;
            private set;
        }
        public DBHandler(string pathToDBFile)
        {
            this.pathToDBFile = pathToDBFile;
            if (!File.Exists(pathToDBFile))
            {
                FileStream fs = new FileStream(pathToDBFile, FileMode.Create);
                fs.Close();
                employeesCount = 0;
            }
            else
            {
                employeesCount = GetLastID();
            }
        }

        public int GetLastID()
        {
            return File.ReadLines(pathToDBFile).Count();
        }


        public bool AddEmployeeToDB(string employer)
        {
            try
            {
                StreamWriter streamWriter = new StreamWriter(pathToDBFile, true);
                streamWriter.WriteLine(employer);
                streamWriter.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
