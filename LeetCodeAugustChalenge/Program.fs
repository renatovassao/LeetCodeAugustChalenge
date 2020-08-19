module Program

open PowerOfFour
open System

[<EntryPoint>]
let main argv =
  let n = 17
  printfn "%d is power of four: %b" n (IsPowerOfFour n)
  0 // return an integer exit code