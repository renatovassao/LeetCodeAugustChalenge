module DesignHashSet

type Tree<'a> =
  | Empty
  | Node of value:'a * left:Tree<'a> * right:Tree<'a>

let rec add value tree =
  match tree with
    | Tree.Empty -> Tree.Node(value, Tree.Empty, Tree.Empty)
    | Tree.Node(current, left, right) ->
      if (value = current) then
        tree
      elif (value < current) then
        Tree.Node(current, add value left, right)
      else
        Tree.Node(current, left, add value right)

let rec contains value tree =
  match tree with
    | Tree.Empty -> false
    | Tree.Node(current, left, right) ->
      if (value = current) then
        true
      elif (value < current) then
        contains value left 
      else
        contains value right

let rec min tree =
  match tree with
    | Tree.Empty -> None
    | Tree.Node(current, left, _) ->
      match left with
      | Tree.Empty -> Some(current)
      | _ -> min left

let rec remove value tree =
  match tree with
    | Tree.Empty -> Tree.Empty
    | Tree.Node(current, left, right) ->
      if (value = current) then
        match left, right with
          | Tree.Empty, Tree.Empty -> Tree.Empty
          | Tree.Empty, Tree.Node(current, left, right)
          | Tree.Node(current, left, right), Tree.Empty -> Tree.Node(current, left, right)
          | _ ->
            match min right with
            | None -> Tree.Empty
            | Some(min) ->
                Tree.Node(min, left, remove min right)
      elif (value < current) then
        Tree.Node(current, remove value left, right)
      else
        Tree.Node(current, left, remove value right) 