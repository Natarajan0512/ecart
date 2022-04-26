using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace API
{
    public class Startup
    {
        private readonly IConfiguration _config;
        public Startup(IConfiguration configuration)
        {
            _config = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
	  	{
            	services.AddControllers();
				services.AddDbContext<StoreContext>(x=> //V1.5
					x.UseSqlite(_config.GetConnectionString("DefaultConnection")));
	  	}
	
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
			app.UseDeveloperExceptionPage();
			}
			
			app.UseHttpsRedirection();
			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints (endpoints =>
			{
			endpoints.MapControllers();
			});

		}
	}
}