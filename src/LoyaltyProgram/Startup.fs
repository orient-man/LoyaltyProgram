namespace LoyaltyProgram

open Microsoft.AspNetCore.Builder
open Nancy.Owin

type Startup () =
    member __.Configure(app: IApplicationBuilder) =
        app.UseOwin(fun buildFunc -> buildFunc.UseNancy() |> ignore)