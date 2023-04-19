using DocumentFormat.OpenXml.Math;
using ISPTF.API.LINQ_Models;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
//using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ISPTF.API
{
    public class Startup
    {
        //readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            DapperORM.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        //private readonly string _policyName = "CorsPolicy";
        //private readonly string _anotherPolicy = "AnotherCorsPolicy";

        // This method gets called by the runtime. Use this method to add services to the container.
        //[SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "<Pending>")]
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigurationHelper.Initialize(Configuration);
            services.AddCors();
            //services.AddCors(opt =>
            //{
            //    opt.AddDefaultPolicy(builder =>
            //    {
            //        builder.AllowAnyOrigin()
            //            .AllowAnyHeader()
            //            .AllowAnyMethod();
            //    });
            //    opt.AddPolicy(name: MyAllowSpecificOrigins, builder =>
            //     {
            //         builder.AllowAnyOrigin()
            //                .AllowAnyHeader()
            //                .AllowAnyMethod();
            //     });
            //});
            services.AddDbContext<ISPTFContext>(
                    options => options.UseSqlServer("Server=203.154.158.182;Database=ISPTF;User Id=sa;Password=ispadmin;"));

            services.AddControllers()
                .AddJsonOptions(options =>
                    options.JsonSerializerOptions.PropertyNamingPolicy = null)
                .AddJsonOptions(options=>
                    options.JsonSerializerOptions.PropertyNameCaseInsensitive=true)
                ;

            var key = Configuration["JwtToken:SecretKey"] + DateTime.Now.ToLongTimeString();
            //var key = Configuration["JwtToken:SecretKey"];
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidIssuer = Configuration["JwtToken:Issuer"],
                    ValidAudience = Configuration["JwtToken:Issuer"],
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key))
                };
            });
            services.AddSingleton<IJwtAuth>(new Auth(key, Configuration));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v3", new OpenApiInfo { Title = "ISPTF.API", Version = "v3" });

                c.EnableAnnotations();

                //By Default, all endpoints are grouped by the controller name
                //We want to Group by Api Group first, then by controller name if group not provided
                c.TagActionsBy((api) => new[] { api.GroupName ?? api.ActionDescriptor.RouteValues["controller"] });

                //Include all endpoints available in the document
                c.DocInclusionPredicate((docName, apiDesc) => { return true; });

                //c.SwaggerDoc("v3", new OpenApiInfo
                //{
                //    Version = "v3",
                //    Title = $"{Configuration["SwaggerDocs_ProductName"]} API",
                //    Contact = new OpenApiContact
                //    {
                //        Name = Configuration["SwaggerDocs_ContactName"],
                //        Email = Configuration["SwaggerDocs_ContactEmail"]
                //    }
                //});

                //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                //c.IncludeXmlComments(xmlPath);
                // c.DocInclusionPredicate((_, api) => !string.IsNullOrWhiteSpace(api.GroupName));

                //c.TagActionsBy(api =>
                //{
                //    if (api.GroupName != null)
                //    {
                //        return new[] { api.GroupName };
                //    }

                //    if (api.ActionDescriptor is ControllerActionDescriptor controllerActionDescriptor)
                //    {
                //        return new[] { controllerActionDescriptor.ControllerName };
                //    }

                //    throw new InvalidOperationException("Unable to determine tag for endpoint.");
                //});

                //c.DocInclusionPredicate((name, api) => true);

                //c.EnableAnnotations();
                //c.SwaggerDoc("v3", new OpenApiInfo { Title = "API", Version = "v3" });

                //c.TagActionsBy(api =>
                //{
                //    if (api.GroupName != null)
                //    {
                //        return new[] { api.GroupName };
                //    }

                //    var controllerActionDescriptor = api.ActionDescriptor as ControllerActionDescriptor;
                //    if (controllerActionDescriptor != null)
                //    {
                //        return new[] { controllerActionDescriptor.ControllerName };
                //    }

                //    throw new InvalidOperationException("Unable to determine tag for endpoint.");
                //});
                //c.DocInclusionPredicate((name, api) => true);
            });
            //services.AddControllers().AddJsonOptions(x =>
            //    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
            services.AddScoped < ISqlDataAccess,SqlDataAccess > ();

            //services.AddApiVersioning(options =>
            //{
            //    options.ReportApiVersions = true;
            //    options.AssumeDefaultVersionWhenUnspecified = true;
            //    options.DefaultApiVersion = new ApiVersion(1, 0);
            //    options.ApiVersionReader = new UrlSegmentApiVersionReader();
            //    options.UseApiBehavior = true;
            //});

            //services.AddVersionedApiExplorer(
            //    options =>
            //    {
            //        options.GroupNameFormat = "'v'VVV";
            //        options.SubstituteApiVersionInUrl = true;
            //        options.AssumeDefaultVersionWhenUnspecified = true;
            //        options.DefaultApiVersion = new ApiVersion(1, 0);
            //    });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public class ResetTheBodyStreamMiddleware
        {
            private readonly RequestDelegate _next;

            public ResetTheBodyStreamMiddleware(RequestDelegate next)
            {
                _next = next;
            }

            public async Task InvokeAsync(HttpContext context)
            {
                // Still enable buffering before anything reads
                context.Request.EnableBuffering();

                // Call the next delegate/middleware in the pipeline
                await _next(context);

                // Reset the request body stream position to the start so we can read it
                context.Request.Body.Position = 0;
            }
        }
        public static class ConfigurationHelper
        {
            public static IConfiguration config;
            public static void Initialize(IConfiguration Configuration)
            {
                config = Configuration;
            }
        };

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("../swagger/v3/swagger.json", "ISPTF.API v3"));

            }
            else
            {
                app.UseSwagger();
                //app.UseSwaggerUI(c => c.SwaggerEndpoint("../swagger/v3/swagger.json", "ISPTF.API v3"));
                app.UseSwaggerUI(c =>
                {
                    c.DisplayOperationId();
                    //c.SwaggerEndpoint("v1/swagger.json", "Menu (version 1)");
                    //c.SwaggerEndpoint("v2/swagger.json", "Menu (version 2)");
                    c.SwaggerEndpoint("v3/swagger.json", "Menu (version 3)");
                });
            }
            //app.UseSerilogRequestLogging();
            //app.UseSerilogRequestLogging(options =>
            //{
            //    options.EnrichDiagnosticContext = (diagnosticContext, httpContext) =>
            //    {
            //        // string body = your logic to get body from httpContext.Request.Body
            //        string body="";
            //        diagnosticContext.Set("Body", body);
            //    };
            //    options.MessageTemplate = "HTTP {RequestMethod} {RequestPath} {Body} responded {StatusCode} in {Elapsed:0.0000}";
            //});
            //app.UseMiddleware<ResetTheBodyStreamMiddleware>();
            app.UseSerilogRequestLogging(options =>
            {
                options.EnrichDiagnosticContext = async (diagnosticContext, context) =>
                  {
                      // Reset the request body stream position to the start so we can read it
                      //context.Request.Body.Position = 0;

                      //// Leave the body open so the next middleware can read it.
                      //using StreamReader reader = new(
                      //    context.Request.Body,
                      //    encoding: Encoding.UTF8,
                      //    detectEncodingFromByteOrderMarks: false);

                      //string body = await reader.ReadToEndAsync();

                      //if (body.Length is 0)
                      //    return;

                      //object? obj = JsonSerializer.Deserialize<object>(body);
                      //if (obj is null)
                      //    return;

                      //diagnosticContext.Set("Body", obj);
                      //options.MessageTemplate = "HTTP {RequestMethod} {RequestPath} {Body} responded {StatusCode} in {Elapsed:0.0000}";
                      options.MessageTemplate = "HTTP {RequestMethod} {RequestPath} responded {StatusCode} in {Elapsed:0.0000}";
                  };
                //options.MessageTemplate = "HTTP {RequestMethod} {RequestPath} {Body} responded {StatusCode} in {Elapsed:0.00000}";
            }
            );
            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseCors(MyAllowSpecificOrigins);

            //app.UseCors(x => x
            //         .AllowAnyMethod()
            //         .AllowAnyHeader()
            //         .SetIsOriginAllowed(origin => true) // allow any origin
            //         .AllowCredentials()); // allow credentials

            //app.UseCors();
            var allowed1 = Configuration["AllowedOrigins"];
            var allowed2 = Configuration["AllowedOrigins2"];

            //app.UseCors(x => x
            //    .WithHeaders("Content-Type", "Accept", "origin")
            //    .WithMethods("POST", "PUT", "DELETE", "HEAD")
            //    .SetPreflightMaxAge(TimeSpan.FromDays(7))
            //    .WithOrigins(allowed1,allowed2)
            //);
            //app.UseCors();
            app.UseCors(x => x
              //  .WithOrigins(allowed1)
               //   .WithHeaders("Content-Type", "Accept", "origin")
                //.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                //.AllowCredentials()
                .SetIsOriginAllowed(origin => true)
            );
            //app.UseCors("AllowSpecific");
            //app.UseCors(_policyName);
            //app.UseCors(_anotherCorsPolicy);

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
