using BLL.Interface_bll;
using BLL.servers_bll;
using DAL.Interface_dal;
using DAL.servers_dal;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebApplication1;


 

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


#region JWT认证


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        //取出私钥
        var secretByte = Encoding.UTF8.GetBytes(builder.Configuration["Authentication:SecretKey"]);
        options.TokenValidationParameters = new TokenValidationParameters()
        {

 

            //验证发布者
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["Authentication:Issuer"],
            //验证接收者
            ValidateAudience = true,
            ValidAudience = builder.Configuration["Authentication:Audience"],
            //验证是否过期
            ValidateLifetime = true,
            //验证私钥
            IssuerSigningKey = new SymmetricSecurityKey(secretByte)
        };
    });


#endregion





//依赖注入
builder.Services.AddTransient(typeof(IBStudents), typeof(BStudents));
builder.Services.AddTransient(typeof(IDStudents), typeof(DStudents));


//初始化数据库
SqlSugarSetup.Init(builder.Services);

//跨域
//builder.Services.AddCors(ret =>
//{
//    ret.AddDefaultPolicy(policy =>
//    {

//        policy.AllowAnyOrigin();
//    });
//});





builder.Services.AddCors(policy =>
{
policy.AddPolicy("CorsPolicy", opt => opt
.AllowAnyOrigin()
.AllowAnyHeader()
.AllowAnyMethod()
.WithExposedHeaders("X-Pagination"));
});
 


var app = builder.Build();


app.MapGet("/test", () => "OK");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//添加jwt验证
app.UseAuthentication();
app.UseAuthorization();


app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();
