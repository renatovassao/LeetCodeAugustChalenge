module DetectCapital

open System

let IsUpper str = str |> String.forall Char.IsUpper
let IsLower str = str |> String.forall Char.IsLower

let rec DetectCapitalUse (str:string) =
  if (str.Length <= 1) then
    true
  else
    match Char.IsUpper str.[0], Char.IsUpper str.[1] with
      | (true, true) -> IsUpper str.[2..]
      | (false, true) -> false
      | (_, false) -> IsLower str.[2..]