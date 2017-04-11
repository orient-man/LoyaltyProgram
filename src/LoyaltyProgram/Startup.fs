namespace LoyaltyProgram

open Microsoft.AspNetCore.Builder
open Nancy
open Nancy.Bootstrapper
open Nancy.Owin
open Nancy.TinyIoc
open LoyaltyProgram.EventFeed

type CustomBootstrapper() =
    inherit DefaultNancyBootstrapper()

    override __.ApplicationStartup(container, pipelines) =
        container.Register<IEventStore, EventStore>() |> ignore

type Startup () =
    member __.Configure(app: IApplicationBuilder) =
        app.UseOwin(fun buildFunc -> buildFunc.UseNancy() |> ignore) |> ignore