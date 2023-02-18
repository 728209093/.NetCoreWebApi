using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;


namespace Model.db
{

    [SugarTable("students")]
    public class students
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true , ColumnDataType="int")]
        public int t_id 
        {
            get; set;
        }

        [SugarColumn(ColumnDescription = "备注", IsNullable=true)]
        public string ? t_description { get; set; }


        [SugarColumn(ColumnDescription ="学生的姓名")]
        public string? t_name { get; set; }


        [SugarColumn(ColumnDescription = "学生的性别")]
        public int t_sex { get; set; }




        [SugarColumn(ColumnDescription = "订单号码")]
        /// <summary>
        /// 订单号码
        /// </summary>
        public long ? t_order_id { get; set; }



        [SugarColumn(ColumnDescription = "创建时间")]
        /// <summary>
        /// 创建时间
        /// </summary>
        public long create_time { get; set; }


        [SugarColumn(ColumnDescription = "更新时间")]

        /// <summary>
        /// 更新时间
        /// </summary>
        public long update_time { get; set; }
    }
}
