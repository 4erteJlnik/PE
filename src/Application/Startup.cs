using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using FluentValidation.AspNetCore;
using FluentValidation;
using Web1.Infrastructure;
using Web1.Services;
using Web1.Infrastructure.AutoMapper;
using Web1.Infrastructure.Repository;
using AutoMapper;
using System.Text;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Web1.Domain;
using Web1.Validation;

namespace Web1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            /*services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "AngularProject/dist";
            });*/
            services.AddCors();
            services.AddControllers();
            services.AddMvc().AddFluentValidation(); ;
            services.AddTransient<IValidator<Post>, PostValidator>();
            services.AddTransient<IValidator<Comments>, CommentsValidator>();
            services.AddSwaggerGen(c =>
            {

                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Web1", Version = "v1" });
                /*var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);*/
                services.AddIdentity<Peoplelogin, IdentityRole<Guid>>(opts =>
               {
                   opts.Password.RequiredLength = 6; // минимальная длина
                   opts.Password.RequireNonAlphanumeric = false; // требуются ли не алфавитно-цифровые символы
                   opts.Password.RequireLowercase = false; // требуются ли символы в нижнем регистре
                   opts.Password.RequireUppercase = false; // требуются ли символы в верхнем регистре
                   opts.Password.RequireDigit = false; // требуются ли цифры
                   opts.User.RequireUniqueEmail = true;    // уникальный email
                   opts.User.AllowedUserNameCharacters = ".@abcdefghijklmnopqrstuvwxyz"; // допустимые символы
               }).AddEntityFrameworkStores<WebContext>()
                  .AddDefaultTokenProviders();
                services.AddTransient<Validation.IPasswordValidator<Peoplelogin>,
                    CustomPasswordValidator>(serv => new CustomPasswordValidator(6));
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });
            });
            switch (Configuration["DbType"])
            {
                case "SQLite":
                    services.AddDbContext<WebContext>(opt => opt.UseSqlite(Configuration.GetConnectionString("SQLite")));
                    break;
                case "PostgreSQL":
                    services.AddDbContext<WebContext>(opt => opt.UseNpgsql(Configuration.GetConnectionString("PostgreSQL")));
                    break;
                case "SQL Server":
                    services.AddDbContext<WebContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("SQL Server")));
                    break;
            }
            services.AddScoped<DbContext>(p => p.GetRequiredService<WebContext>());
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IPostCommentRepository, PostCommentRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IPeopleRepository, PeopleRepository>();
            services.AddScoped<IFileRepository, FileReposiry>();
            services.AddTransient<SignInManager<Peoplelogin>>();
            services.AddTransient<UserManager<Peoplelogin>>();
            services.AddScoped<RoleManager<IdentityRole<Guid>>>();
            services.AddTransient<CommentService>();
            services.AddTransient<PostService>();
            services.AddTransient<FileService>();
            services.AddTransient<PeopleService>();
            services.AddSingleton<FTPlink>(Configuration["FTP:Login"] != null
                ? new FTPlink(Configuration["FTP:Adress"], Configuration["FTP:Login"], Configuration["FTP:Password"],
                    bool.Parse(Configuration["FTP:SSL"]))
                : new FTPlink(Configuration["FTP:Adress"]));
            services.AddAutoMapper(typeof(ApplicationMapperProfile));
            services.AddIdentity<Peoplelogin, IdentityRole<Guid>>(opts =>
                {
                    opts.Password.RequiredLength = 6; // минимальная длина
                    opts.Password.RequireNonAlphanumeric = false; // требуются ли не алфавитно-цифровые символы
                    opts.Password.RequireLowercase = false; // требуются ли символы в нижнем регистре
                    opts.Password.RequireUppercase = false; // требуются ли символы в верхнем регистре
                    opts.Password.RequireDigit = false; // требуются ли цифры
                    opts.User.RequireUniqueEmail = true;    // уникальный email
                    opts.User.AllowedUserNameCharacters = ".@abcdefghijklmnopqrstuvwxyz"; // допустимые символы
                })
                .AddEntityFrameworkStores<WebContext>()
                .AddDefaultTokenProviders();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Web1 v1"));
            }
            /*  if (!env.IsDevelopment())
             {
                 app.UseSpaStaticFiles();
             }
            app.UseSpa(spa =>
             {
                 spa.Options.SourcePath = "AngularProject";
                 spa.UseAngularCliServer(npmScript: "start");
             });*/

            //app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseCors(builder =>
            {
                builder.WithOrigins("https://localhost:4200");
                builder.AllowAnyMethod();
                builder.AllowAnyHeader();
                builder.AllowCredentials();
            });

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
