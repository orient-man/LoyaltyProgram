namespace LoyaltyProgram

open System
open Nancy
open LoyaltyProgram.EventFeed

type EventsFeedModule(eventStore: IEventStore) as this =
    inherit NancyModule("/events")

    let tryParse = Int64.TryParse >> function true, value -> Some value | _ -> None

    do
        this.Get("/", fun _ ->
            let first = this.Request.Query?start.Value |> tryParse |> defaultArg <| 0L
            let last = this.Request.Query?``end``.Value |> tryParse |> defaultArg <| 50L
            eventStore.GetEvents(first, last))