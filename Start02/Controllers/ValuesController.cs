using BLL.Interface_bll;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;
using WebApplication1;
using Model;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;

namespace Start02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        Queue<string> duilie = new Queue<string>();

  
        private readonly IBStudents _IBStudents;

        ILogger<ValuesController> logger;
     

        public ValuesController(IBStudents bStudents, ILogger<ValuesController> logger)
        {

            _IBStudents = bStudents;
            this.logger = logger;
        }

    
        [HttpPost("CreateStudents")]
        public ActionResult<dynamic> CreateStudents(string name,string sex)
        {

            var students = new Model.db.students();

 
 
            students.create_time = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds(); ;
            students.t_name = name;
            students.t_order_id =  9986;
            students.t_sex = sex == "男" ? 1 : 0;

 
 

            


            int count = SqlSugarSetup.db.Insertable(students).ExecuteCommand();

            //var ret = _IBStudents.GetStudents();

            var meg = count  > 0 ? "插入成功" : "插入失败";
 
            return meg;
        }




        [HttpGet("GetList")]
        [Authorize]
        public ActionResult<dynamic> GetList()
        {
            string authHeader = this.Request.Headers["Authorization"];//Header中的token


            authHeader = authHeader.Split("bearer ")[1];

            var userinfo = new JwtSecurityTokenHandler().ReadToken(authHeader);

 
            var ret = SqlSugarSetup.db.Queryable<Model.db.students>().ToList();
 
            return userinfo;


        }


 
        [HttpPost("Inster")]
        public ActionResult<dynamic> Inster(string name)
        {

           
            var obj = new students()
            {
  
                name = name.ToString(),
                sex = 1,

            };

            var ret=SqlSugarSetup.db.Insertable(obj).ExecuteReturnIdentity();
            return ret;

            
        }




        [HttpGet("Reverse")]
        public   string  Reverse(string zfc)
        {

            //首先接受字符串转为char[]数组类型
            //然后使用arr.reverse反序列化数组
            //最后再把数组使用string.join转为字符串输出



            var tochararry = zfc.ToCharArray();


             Array.Reverse(tochararry);


            var str = string.Join("",tochararry);

 

            return str;
        }







        /// <summary>
        /// 重写方法
        /// </summary>
        /// <param name="K">输入的字符串</param>
        [HttpGet("OverRide")]
        public void OverRide(string K)
        {


            Override_sum override_Sum = new Override_sum();

            override_Sum.test(K);
        }




        /// <summary>
        /// 重载方法测试
        /// </summary>
        /// <param name="K"></param>
        [HttpGet("OverLoad")]
        public void OverLoad(string K)
        {
            OverLoad overLoad = new OverLoad();


            overLoad.Student();


            overLoad.Student(K, 1);


 
        }



        /// <summary>
        /// 入队
        /// </summary>
        [HttpGet("Enqueue")]
        public ActionResult<dynamic> Enqueue(string yuansu)
        {

            duilie.Enqueue(yuansu);


            data<List<string>> data = new data<List<string>>();
 

            List<string> strings = new List<string>();


            strings.Add("QQ");




            data.code = 200;
            data.message = "当前队列的长度是，" + duilie.Count;
            data.Data = strings;

            return data;
 

        }

    }
}
