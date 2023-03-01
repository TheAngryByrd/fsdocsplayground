dotnet fsdocs build --input docsSrc --output docs --parameters root fsdocsplayground/ fsdocs-release-notes-link https://github.com/TheAngryByrd/IcedTasks/blob/master/CHANGELOG.md fsdocs-key1 lololol


@REM   --input               (Default: docs) Input directory of documentation content.

@REM   --projects            Project files to build API docs for outputs, defaults to all packable projects.

@REM   --output              Output Folder (default 'output' for 'build' and 'tmp/watch' for 'watch'.

@REM   --noapidocs           (Default: false) Disable generation of API docs.

@REM   --ignoreprojects      (Default: false) Disable project cracking.

@REM   --eval                (Default: false) Evaluate F# fragments in scripts.

@REM   --qualify             (Default: false) In API doc generation qualify the output by the collection name, e.g. 'reference/FSharp.Core/...' instead of 'reference/...' .

@REM   --saveimages          (Default: none) Save images referenced in docs (some|none|all). If 'some' then image links in formatted results are saved for latex and ipynb output docs.

@REM   --sourcefolder        Source folder at time of component build (defaults to value of `<FsDocsSourceFolder>` from project file, else current directory)

@REM   --sourcerepo          Source repository for github links (defaults to value of `<FsDocsSourceRepository>` from project file, else `<RepositoryUrl>/tree/<RepositoryBranch>` for Git repositories)

@REM   --linenumbers         (Default: false) Add line numbers.

@REM   --nonpublic           (Default: false) The tool will also generate documentation for non-public members

@REM   --mdcomments          (Default: false) Assume /// comments in F# code are markdown style (defaults to value of `<UsesMarkdownComments>` from project file)

@REM   --parameters          Additional substitution substitutions for templates, e.g. --parameters key1 value1 key2 value2

@REM   --nodefaultcontent    Do not copy default content styles, javascript or use default templates.

@REM   --properties          Provide properties to dotnet msbuild, e.g. --properties Configuration=Release Version=3.4

@REM   --fscoptions          Extra flags for F# compiler analysis, e.g. dependency resolution.

@REM   --clean               (Default: false) Clean the output directory.

@REM   --help                Display this help screen.

@REM   --version             Display version information.
