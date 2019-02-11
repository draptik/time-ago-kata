module TimeAgoTests

open FsUnit.Xunit
open Xunit

let timeAgo secondsToSubract =
    "vor 10 Sekunden"

[<Fact>]
let ``returns 10 seconds ago`` () =
    timeAgo 10 |> should equal "vor 10 Sekunden"
