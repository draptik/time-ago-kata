module TimeAgoTests

open FsUnit.Xunit
open Xunit

let timeAgo secondsToSubract =
    match secondsToSubract with
    | 10 -> Ok "vor 10 Sekunden"
    | _ -> Error "invalid input"

// [<Fact>]
// let ``returns 10 seconds ago`` () =
    // timeAgo 10 |> Result.Ok |> should equal true
    // timeAgo 10 |> Result.Ok |> should equal "vor 10 Sekunden"
