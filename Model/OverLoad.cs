using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{

    /// <summary>
    /// 重载方法测试
    /// </summary>
    public class OverLoad
    {


        public void Student()
        {
            Console.WriteLine("无参构造函数");
        }
        public void Student(string name, int code)
        {
            Console.WriteLine("具有两个参数的构造函数");
        }
 


    }
}
