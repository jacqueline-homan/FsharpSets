open System
open System.Collections.Generic
open System.Diagnostics
open System.IO
open System.Web

(* let time f =
    let sw = StopWatch()
    sw.Start()
    f()
*)


let time f =
    let start = DateTime.Now
    let res = f()
    let finish = DateTime.Now
    (res, finish - start)
time(fun () -> "http://www.newscientist.com") |> printfn "%A"


[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    0 // return an integer exit code

