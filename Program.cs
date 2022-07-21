using BrandMonitorTest;

await Host.CreateDefaultBuilder().ConfigureWebHostDefaults(webbuilder => webbuilder.UseStartup<Startup>()).Build().RunAsync();
