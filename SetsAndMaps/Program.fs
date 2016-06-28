open System
open System.IO
open System.Collections.Generic

let muppets = Set(["Oscar the Grouch"; "Snuffalupagus"; "Big Bird"])

let moreMuppets = 
    ["Oscar the Grouch"; "Snuffalupagus"; "Big Bird"; "Bert"; "Ernie"]
    |> Set.ofList

let moreMuppets' = moreMuppets.Add("Cookie Monster")

printfn "%A" moreMuppets'

[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    0 // return an integer exit code

