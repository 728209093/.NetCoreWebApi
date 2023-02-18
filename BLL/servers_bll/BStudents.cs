using BLL.Interface_bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL.Interface_dal;

namespace BLL.servers_bll
{
    public class BStudents: IBStudents
    {


        private readonly IDStudents _IDStudents;


        public BStudents(IDStudents dStudents)
        {

            _IDStudents = dStudents;
        }

         


        public List<students> GetStudents()
        {

            var ret = _IDStudents.GetStudents();

            return ret;
        }
    

 
    
    
    
    
    }
  
 
}
