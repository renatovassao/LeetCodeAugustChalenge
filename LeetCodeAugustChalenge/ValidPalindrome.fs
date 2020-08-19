module ValidPalindrome

open System

let FirstLetterOrDigitIndex str = str |> Array.tryFindIndex Char.IsLetterOrDigit
let LastLetterOrDigitIndex str = str |> Array.tryFindIndexBack Char.IsLetterOrDigit

let rec IsPalindrome (str:string) =
  if str.Length <= 1 then
    true
  else
    let arr = str.ToCharArray()
    match (FirstLetterOrDigitIndex arr, LastLetterOrDigitIndex arr) with
      | Some(i), Some(j) ->
        Char.ToLower str.[i] = Char.ToLower str.[j] && IsPalindrome(str.[(i + 1)..(j - 1)])
      | _ -> true