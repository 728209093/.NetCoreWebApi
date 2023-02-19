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


#region JWT��֤


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        //ȡ��˽Կ
        var secretByte = Encoding.UTF8.GetBytes(builder.Configuration["Authentication:SecretKey"]);
        options.TokenValidationParameters = new TokenValidationParameters()
        {

 

            //��֤������
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["Authentication:Issuer"],
            //��֤������
            ValidateAudience = true,
            ValidAudience = builder.Configuration["Authentication:Audience"],
            //��֤�Ƿ����
            ValidateLifetime = true,
            //��֤˽Կ
            IssuerSigningKey = new SymmetricSecurityKey(secretByte)
        };
    });


#endregion





//����ע��
builder.Services.AddTransient(typeof(IBStudents), typeof(BStudents));
builder.Services.AddTransient(typeof(IDStudents), typeof(DStudents));


//��ʼ�����ݿ�
SqlSugarSetup.Init(builder.Services);

//����
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

//���jwt��֤
app.UseAuthentication();
app.UseAuthorization();


app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();
