using System.IO.Compression;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using UnitedModels.Simple.Grpc.Service.GrpcServices;

namespace UnitedModels.Simple.Grpc.Service
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGrpc(options =>
            {
                options.ResponseCompressionAlgorithm = "gzip";
                options.ResponseCompressionLevel = CompressionLevel.Optimal;
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<PersonGrpcService>();
            });
        }
    }
}