var host = new WebHostBuilder()
                .UseKestrelCore()
                .Configure(app =>
                {
                    app.Run(context => context.Response.WriteAsync("Hello World"));
                })
                .Build();
host.Run();
