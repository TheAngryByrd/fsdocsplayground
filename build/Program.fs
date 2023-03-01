open Fake.Core
open Fake.DotNet
open Fake.IO.Globbing.Operators
open Fake.IO.FileSystemOperators
open System




let rootDir = __SOURCE_DIRECTORY__ </> ".."
let src = rootDir </> "src"
// please set '<FsDocsLicenseLink>' in 'Directory.Build.props'
// please set '<FsDocsReleaseNotesLink>' in 'Directory.Build.props'
// please set '<Version>' in 'Directory.Build.props'
// please set '<RepositoryUrl>' in 'Directory.Build.props'
let srcProjGlob = !! (src </> "**/*.??proj")

let docsSrc = rootDir </> "docsSrc"
let docs =  rootDir </> "docs"
let docsPublicRoot = "https://jimmybyrd.me/fsdocsplayground/"
let projectName = "FsDocs Playground"
let githubProjectRootUrl = Uri("https://github.com/TheAngryByrd/fsdocsplayground/")

let licenseUrl = Uri(githubProjectRootUrl, "blob/main/LICENSE.md")
let changelogUrl = Uri(githubProjectRootUrl, "blob/main/CHANGELOG.md")

let quoted s = $"\"%s{s}\""

let initTargets () =
  Target.create "BuildDocs" (fun _ ->
    ()
    Fsdocs.build (fun p -> {
      p with
        Clean = Some true
        Input = Some docsSrc
        Output = Some docs
        // Projects = Some srcProjGlob
        Parameters = Some [
            "root", quoted docsPublicRoot
            "fsdocs-collection-name", quoted projectName
            "fsdocs-license-link", quoted (licenseUrl.ToString())
            "fsdocs-release-notes-link", quoted (changelogUrl.ToString())
            "fsdocs-repository-link", quoted(githubProjectRootUrl.ToString())
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