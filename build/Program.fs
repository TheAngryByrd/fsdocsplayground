open Fake.Core
open Fake.DotNet
open Fake.IO.Globbing.Operators
open Fake.IO.FileSystemOperators
open System




let rootDir = __SOURCE_DIRECTORY__ </> ".."
IO.Directory.SetCurrentDirectory rootDir
let src = "src"
// please set '<FsDocsLicenseLink>' in 'Directory.Build.props'
// please set '<FsDocsReleaseNotesLink>' in 'Directory.Build.props'
// please set '<Version>' in 'Directory.Build.props'
// please set '<RepositoryUrl>' in 'Directory.Build.props'
let srcProjGlob = !! (src </> "**/*.??proj")

let docsSrc = "docsSrc"
let docs = "docs"
let docsPublicRoot = "https://www.jimmybyrd.me/fsdocsplayground/"
let projectName = "FsDocs Playground"
let githubProjectRootUrl = Uri("https://github.com/TheAngryByrd/fsdocsplayground/")
let READMElink = Uri(githubProjectRootUrl, "blob/master/README.md")

let quoted s = $"\"%s{s}\""

let version = "0.5.3"

let initTargets () =



  Target.create "BuildDocs" (fun _ ->
    // hack to fix projects
    let srcProjGlob = String.Join(" ", srcProjGlob |> Seq.map quoted)
    Fsdocs.build (fun p -> {
      p with
        Clean = Some true
        Input = Some docsSrc
        Output = Some docs
        // Projects = Some [srcProjGlob]
        Parameters = Some [
            // https://fsprojects.github.io/FSharp.Formatting/content.html#Templates-and-Substitutions
            "root", quoted docsPublicRoot
            "fsdocs-collection-name", quoted projectName
            "fsdocs-repository-link", quoted(githubProjectRootUrl.ToString())
            "fsdocs-package-version", quoted version
            "fsdocs-readme-link", quoted (READMElink.ToString())
          ]
    })
  )

  Target.create "WatchDocs" (fun _ ->
    ()
    // Fsdocs.watch (fun p -> {
      
    //   p with
    //     Input = Some docsSrc
    //     Output = Some docs
    //     Parameters = Some ["root", docsPublicRoot]
    // })
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
    Target.runOrDefault "BuildDocs"
    0