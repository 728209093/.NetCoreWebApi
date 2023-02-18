using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{

    //父类中的方法
    public class Override
    {


        public void test(string k)
        {

            Console.Write("我是父类中的方法,", k);
        }
    }




    public class Override_sum : Override
    {

        public new  void test(string k)
        {

            Console.Write("我是子类中的方法,", k);
        }

    }
}
