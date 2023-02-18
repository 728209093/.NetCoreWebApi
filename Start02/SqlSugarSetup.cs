using SqlSugar;
using Model;
using Microsoft.Data.Sqlite;
using MySql.Data.MySqlClient;
using System.Reflection;

namespace WebApplication1
{



    public class SqlSugarSetup
    {

 
        public static SqlSugarClient db
        {
            get
            {
                return new SqlSugarClient(new ConnectionConfig()
                {
                    ConnectionString = "Data Source=localhost;User ID=root;Password=root;Database=test;Allow User Variables=True;Charset=utf8;",//数据库连接字符串
                    DbType = DbType.MySql,//DbType支持Mysql、SqlServer、Sqlite、Oracle、PostgreSQL等多种数据库
                    IsAutoCloseConnection = true,//自动释放
                    InitKeyType = InitKeyType.Attribute



                });

            }

        }
 

        public static void Init(IServiceCollection services)
        {


 
            ////自动创建数据库
            db.DbMaintenance.CreateDatabase();//如果不存在创建数据库

            //采用Codefirst方式
            //设置varchar类型 字段默认长度为200
            //也就是string类型的字段长度给一个默认长度，节省数据空间
            //如果有多张表需要初始化，上句可重复写，或者批量初始化（后面会写到...）
 
 
            db.CodeFirst.SetStringDefaultLength(200).InitTables(typeof(Model.db.students));//创建数据表
 
            Console.WriteLine("数据表初始化成功！！");

 
            //单例注入，方便控制器或其他类中使用数据库实例对象
            services.AddSingleton<ISqlSugarClient>(db);
        }


 
 
    }

 
}
