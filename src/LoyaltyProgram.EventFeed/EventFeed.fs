namespace LoyaltyProgram.EventFeed

open System
open System.Collections.Generic
open System.Linq
open System.Threading

[<CLIMutable>]
type Event = {
    SequenceNumber: Int64
    OccuredAt: DateTimeOffset
    Name: string
    Content: obj }

type IEventStore =
    abstract member GetEvents: first: Int64 * last: Int64 -> Event list
    abstract member Raise: eventName: string * content: obj -> unit

type EventStore() =
    static let mutable currentSequenceNumber = 0L
    static let database = List<_>()

    interface IEventStore with
        member __.GetEvents(first, last) =
            database
            |> Seq.filter (fun e -> e.SequenceNumber >= first && e.SequenceNumber <= last)
            |> Seq.sortBy (fun e -> e.SequenceNumber)
            |> List.ofSeq

        member __.Raise(eventName, content) =
            let seqNumber = Interlocked.Increment(&currentSequenceNumber)
            database.Add(
                {   SequenceNumber = seqNumber
                    OccuredAt = DateTimeOffset.UtcNow
                    Name = eventName
                    Content = content })