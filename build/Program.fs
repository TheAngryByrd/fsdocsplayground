open Fake.Core
open Fake.DotNet
open Fake.IO.FileSystemOperators


let rootDir = __SOURCE_DIRECTORY__ </> ".."

let docsSrc = rootDir </> "docsSrc"
let docs =  rootDir </> "docs"
let docsPublicRoot = "https://jimmybyrd.me/fsdocsplayground/"

let initTargets () =
  // *** Define Targets ***
  Target.create "BuildDocs" (fun _ ->
    ()
    Fsdocs.build (fun p -> {
      p with
        Clean = Some true
        Input = Some docsSrc
        Output = Some docs
        Parameters = Some ["root", docsPublicRoot]
    })
  )

  ()

[<EntryPoint>]
let main argv =
    argv
    |> Array.toList
    |> Context.FakeExecutionContext.Create false "build.fsx"
    |> Context.RuntimeContext.Fake
    |> Context.setExecutionContext

    initTargets ()
    // *** Start Build ***
    Target.runOrDefault "BuildDocs"
    0 // return an integer exit code