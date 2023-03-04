(**
---
title: A Literate Script
category: Examples
categoryindex: 2
index: 1
---


# Hello World

*)

#r "nuget: FsToolkit.Errorhandling"
open FsToolkit.ErrorHandling

let test : Result<string,string> = result { return "foo"}

printf "A result is: %A" test
(*** include-output ***)