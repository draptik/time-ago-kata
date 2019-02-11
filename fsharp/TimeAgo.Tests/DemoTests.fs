module DemoTests

open FsUnit.Xunit
open Xunit

[<Fact>]
let ``My test`` () =
    Assert.True(true)

[<Theory>]
[<InlineData(1, 2, 3)>]
let ``Parameterized test`` (a : int) (b : int) (expected : int) =
    Assert.True(a + b = expected)

[<Theory>]
[<InlineData(1, 2, 3)>]
let ``Parameterized test using Equal`` (a : int) (b : int) (expected : int) =
    Assert.Equal(a + b, expected)

[<Theory>]
[<InlineData(1, 2, 3)>]
let ``Parameterized test using idiomatic FSharp (FsUnit)`` (a : int) (b : int) (expected : int) =
    a + b 
    |> should equal expected

[<Theory>]
[<InlineData(1, 2, 3)>]
let ``Parameterized test with type inference`` a b expected =
    a + b |> should equal expected

// `a` in F# is like `T` in C#...
[<Theory>]
[<InlineData(1, 2, 3)>]
let ``Parameterized test using idiomatic variable names`` x1 x2 expected =
    x1 + x2 |> should equal expected


[<Fact>]
let ``Call an internal function from test`` () =
    let doMagic x y =
        x + y
    doMagic 1 2 |> should equal 3
    
let doMoreMagic x y =
    x + y

[<Fact>]
let ``Call a function from test`` () =
    doMoreMagic 1 2 |> should equal 3