namespace SEOApi.Extensions
{
    /// <summary>
    /// Extensions for adding CORs policies
    /// </summary>
    public static class CorsServiceExtensions
    {
        /// <summary>
        /// CORs policy for our back-end
        /// </summary>
        /// <param name="services"></param>
        /// <param name="allowedOrigins"></param>
        /// <returns></returns>
        public static IServiceCollection AddCustomCors(this IServiceCollection services, string[] allowedOrigins)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder =>
                    {
                        builder.WithOrigins(allowedOrigins)
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });

                // Add other policies as needed
            });

            return services;
        }
    }
}
