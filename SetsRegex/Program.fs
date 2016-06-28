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

let dirUniqueWords dirName = 
    dirName
    |> Directory.EnumerateFiles
    |> Seq.collect fileWords


fileWords @"/home/jacque/Documents/career.txt"
|> Set.ofSeq
|> Seq.truncate 100
|> Seq.iter(fun w -> printfn "%s" w)

[<EntryPoint>]
let main argv = 
    //printfn "%A" argv
    0 // return an integer exit code

