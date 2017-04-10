module LoyaltyProgram.Program

open System.IO
open Microsoft.AspNetCore.Hosting
open LoyaltyProgram

[<EntryPoint>]
let main _ =
    let host =
        WebHostBuilder()
            .UseKestrel()
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseStartup<Startup>()
            .Build()

    host.Run()
    0