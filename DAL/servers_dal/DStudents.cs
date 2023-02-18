using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface_dal;
using Model;

namespace DAL.servers_dal
{
    public class DStudents:IDStudents
    {


        public List<students> GetStudents()
        {


            List<students> students = new List<students>();


            for (int i = 0; i < 2; i++)
            {

                var singone = new students();

                Random random = new Random();


                singone.id = i;
                singone.name = "X" + i;
                singone.sex = random.Next(0, 1);



                students.Add(singone);


            }


            return students;


 

        }
 

    }
}
