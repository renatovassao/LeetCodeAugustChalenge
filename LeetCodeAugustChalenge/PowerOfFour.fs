module PowerOfFour

open System

let IsPowerOfFour n = 
  let power = (Math.Log (float n) / Math.Log 4.0)
  power = Math.Round(power)