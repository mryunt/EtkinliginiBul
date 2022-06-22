using EtkinliginiBul.Business.Abstract;
using EtkinliginiBul.Business.Concrete;
using EtkinliginiBul.DAL.Context;
using Microsoft.OpenApi.Models;

namespace EtkinliginiBul.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options => options.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            }));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EtkinliginiBul.WebAPI", Version = "v1" });
            });
            services.AddDbContext<EtkinliginiBulDbContext>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IEventTypeService, EventTypeService>();
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<ISalonService, SalonService>();
            services.AddScoped<ISeatService, SeatService>();
            services.AddScoped<IImagesService, ImagesService>();

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("MyPolicy");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EtkinliginiBul.WebAPI v1"));
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    }
}
