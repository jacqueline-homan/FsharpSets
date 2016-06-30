open System
open System.IO
open System.Collections.Generic

let moons = 
    Map([("Mercury", 0); ("Venus", 0); ("Earth", 1); ("Mars", 2); ("Jupiter", 67); ("Saturn", 62); ("Neptune", 13); ("Uranus", 27)])

let moons2 =
    [("Mercury", 0); ("Venus", 0); ("Earth", 1); ("Mars", 2); ("Jupiter", 67); ("Saturn", 62); ("Neptune", 13); ("Uranus", 27)]
    |> Map.ofSeq

//printfn "%A" moons
//printfn "%A" moons2 

let elements = 
    [
        "Hydrogen", 1
        "Helium", 2
        "Lithium", 3
        "Beryllium", 4
        "Boron", 5
        "Carbon", 6
        "Nitrogen", 7
        "Oxygen", 8
        "Flourine", 9
        "Neon", 10
    ] |> Map.ofList 

elements.["Boron"] |> printfn "%A"

let elements' = elements.Add("Sodium", 11)
elements'.["Sodium"] |> printfn "%A"



[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    0 // return an integer exit code

