open Fake.Core
open Fake.DotNet
open Fake.IO.Globbing.Operators
open Fake.IO.FileSystemOperators
open Fake.Core.TargetOperators
open System
open System.IO



let absolutePath (p : string) = DirectoryInfo(p).FullName

let rootDir = __SOURCE_DIRECTORY__ </> ".."
IO.Directory.SetCurrentDirectory rootDir
let src = "src"
let srcProjGlob = !! (src </> "**/*.??proj")

let defaultBranch = "master"

let docsSrc = "docsSrc"
let docs = "docs"
let docsPublicRoot = "https://www.jimmybyrd.me/fsdocsplayground/"
let projectName = "FsDocs Playground"
let githubProjectRootUrl = Uri("https://github.com/TheAngryByrd/fsdocsplayground/")
let READMElink = Uri(githubProjectRootUrl, $"blob/{defaultBranch}/README.md")
let CHANGELOGlink = Uri(githubProjectRootUrl, $"blob/{defaultBranch}/CHANGELOG.md")

let quoted s = $"\"%s{s}\""

let version = "0.5.3"

let temp = "temp"
let watchDocsDir = temp </> "watch-docs"


let initTargets () =

  let fsDocsDotnetOptions (o : DotNet.Options) =
    {  o with
          WorkingDirectory = rootDir
    }


  let fsDocsBuildParams (p : Fsdocs.BuildCommandParams) =
    { p with
        Clean = Some true
        Input = Some (quoted docsSrc)
        Output = Some (quoted docs)
        Eval = Some true
        Projects = Some (Seq.map quoted srcProjGlob)
        Properties = Some ($"Version={version} PackageVersion={version}")
        Parameters = Some [
            // https://fsprojects.github.io/FSharp.Formatting/content.html#Templates-and-Substitutions
            "root", quoted docsPublicRoot
            "fsdocs-collection-name", quoted projectName
            "fsdocs-repository-branch", quoted defaultBranch
            "fsdocs-repository-link", quoted(githubProjectRootUrl.ToString())
            "fsdocs-package-version", quoted version
            "fsdocs-readme-link", quoted (READMElink.ToString())
            "fsdocs-release-notes-link", quoted (CHANGELOGlink.ToString())
          ]
        Strict = Some true
    }

  Target.create "CleanDocsCache" (fun  _ ->
    Fsdocs.cleanCache rootDir
  )

  Target.create "BuildDocs" (fun _ ->
    Fsdocs.build fsDocsDotnetOptions (fsDocsBuildParams)
  )

  Target.create "WatchDocs" (fun _ ->
    let buildParams bp =
      let bp =  Option.defaultValue Fsdocs.BuildCommandParams.Default bp |> fsDocsBuildParams 
      { bp with
          Output = Some watchDocsDir
      }

    Fsdocs.watch fsDocsDotnetOptions (fun p ->
      {p with
        BuildCommandParams = Some(buildParams p.BuildCommandParams)
      }
    )
  )

  "CleanDocsCache" ==> "BuildDocs" |> ignore
  "CleanDocsCache" ==> "WatchDocs" |> ignore


[<EntryPoint>]
let main argv =
    argv
    |> Array.toList
    |> Context.FakeExecutionContext.Create false "build.fsx"
    |> Context.RuntimeContext.Fake
    |> Context.setExecutionContext

    initTargets ()
    Target.runOrDefault "WatchDocs"
    0