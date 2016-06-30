open System
open System.Collections.Generic
open System.IO
open System.Text.RegularExpressions

let re = Regex("\w+")
let toWords str =
    seq { for m in re.Matches(str) -> m.Value}
//toWords "The quick brown fox jumped over the lazy dog" |> printfn "%A"
let fileWords fileName =
    fileName
    |> File.ReadLines
    |> Seq.collect toWords
    |> Seq.map(fun w -> w.ToLowerInvariant())
    |> Seq.filter(fun w -> w.IndexOfAny([|'a'..'z'|]) > -1)
    |> Seq.filter(fun w -> w.IndexOfAny([|'0'..'9'|]) = -1)
    |> Seq.filter(fun w -> w.IndexOfAny([|'_'|]) = -1)

let dirUniqueWords dirName = 
    dirName
    |> Directory.EnumerateFiles
    |> Seq.collect fileWords
    |> Set.ofSeq

let foods = dirUniqueWords @"/home/jacque/Documents/IndianGarden"
let beverages = dirUniqueWords @"/home/jacque/Documents/Brew"
    
let foodsNotBeverages = Set.difference foods beverages |> Set.iter(printfn "%s")
let nonsense = toWords("The quick brown fox jumped over the lazy dog") |> Set.ofSeq  
let words = 
    [foods; beverages; nonsense]
    |> Set.unionMany
    |> Set.count
    |> printfn "%i" //prints out the total word count from the set union

let isThere = Set.isSubset foods beverages |> printfn "%A"
let howAbout = Set.isProperSubset foods beverages |> printfn "%A"
let andAbout = Set.isSuperset foods beverages |> printfn "%A"
let lastly = Set.isProperSuperset foods beverages |> printfn "%A"
let whatAbout = Set.isSubset foods nonsense |> printfn "%A" 
let orAbout = Set.isProperSubset foods nonsense |> printfn "%A"
let check1 = Set.isSubset beverages nonsense |> printfn "%A"
let check2 = Set.isProperSubset beverages nonsense |> printfn "%A"
let check3 = Set.isSuperset beverages nonsense |> printfn "%A"
let check4 = Set.isProperSuperset beverages nonsense |> printfn "%A"

nonsense - beverages |> printfn "%A"
nonsense - foods |> printfn "%A"
foods - nonsense |> printfn "%A"
beverages - nonsense |> printfn "%A"


[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    0 // return an integer exit code

