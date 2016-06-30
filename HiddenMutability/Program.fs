open System
open System.IO
open System.Text
open System.Security.Cryptography

let secretPassword = "abc123"

let stringMD5 (str:string) = 
    use md5 = MD5.Create()
    md5.ComputeHash(Encoding.UTF8.GetBytes(str))

let attemptsTried =
    let attempts = ref Set.empty
    (fun pswdhsh -> 
        attempts := Set.add pswdhsh !attempts
        (!attempts).Count)
    
let checkPswd (pswd:string) =
    let attempts = attemptsTried(stringMD5 pswd)
    if attempts > 3 then 
        "You're been locked out after 3 attempts"
    else 
        if pswd = secretPassword then
            "OK"
        else
            "Try Again"

[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    0 // return an integer exit code

