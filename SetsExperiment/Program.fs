open System
open System.Collections.Generic
open System.IO

type FoodAllergies =
    | PeanutProducts
    | Honey
    | Eggs
    | Grains


type Patient = 
    | NoAllergies 
    | Allergies of Set<FoodAllergies> 

let rec patient():Patient =
    printfn "Do you have any food allergies? (Y/N)"
    let resp = Console.ReadLine().Trim().ToUpper()
    match resp with
    | "y" -> Patient (Allergies, resp)
    | "n" -> Patient (NoAllergies, resp)
             printfn "Thank you. Goodbye" 
             (exit(0)) 
    | _ -> printfn "Invalid Entry"
           patient()
let exit() = 0
   

let whichFoods():Set<FoodAllergies> =
    let rec bad(s:Set<FoodAllergies>):Set<FoodAllergies> =
        printfn "Which foods are you allergic to?"
        printfn "Peanuts, Honey, Eggs, Grains"
        printfn "Enter zero or more of these and type 'Done' when done"
        let response = Console.ReadLine()
        match response.Trim().ToLower() with
        | "done" -> s
        | _ ->
            let n = 
                match response.Trim().ToLower() with
                | "peanuts" -> Some PeanutProducts
                | "honey" -> Some Honey
                | "eggs" -> Some Eggs
                | "grains" -> Some Grains
                | _ -> printfn "Invalid Entry"
                       None
            match n with
            | None -> bad(s)
            | Some(x) -> bad(s.Add(x))
    bad(new Set<FoodAllergies>([]))

         
let fx(canteat:Set<FoodAllergies>) =
    Seq.iter(fun x ->
        match x with
        | PeanutProducts -> printfn "Peanuts"
        | Honey -> printfn "Honey"
        | Eggs -> printfn "Eggs"
        | FoodAllergies.Grains -> printfn "Grains")(canteat)




[<EntryPoint>]
let main argv = 
    let p = patient()
    0 // return an integer exit code

