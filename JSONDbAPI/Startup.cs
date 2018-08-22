using System.Collections.Generic;
using JSONToDatabaseReader.Datamodel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JSONDbAPI
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            var filename = Configuration["JSONSongFile"];
            var songlist = JSONToDatabaseReader.ReadJSONAndWriteToDb.ReadFile<List<Song>>(filename);
            var filteredsonglist = JSONToDatabaseReader.ReadJSONAndWriteToDb.FilterEnumerable(songlist, x => x.Genre.Contains("Metal") && x.Year < 2016);
            var repository = new JSONToDatabaseReader.Repository.NHibernateRepository<Song>();
            foreach (var item in filteredsonglist)
            {
                repository.Save(item);
            }
            services.AddSingleton(repository);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
