namespace Project1
open System

/// <namespacedoc>
///   <summary>Contains core functionality for Project1.</summary>
/// </namespacedoc>
/// 
/// <summary>
/// Core functionality for saying hello
/// </summary>
module Say =
    /// <summary>
    /// The Foo Type
    /// </summary>
    type Foo = 
        { 
            /// Is a Name
            Name : string
            /// is a datetime
            Date : DateTime
        }
            with 
                /// <summary>Record static member example</summary>
                /// <param name="name">Does a thing</param>
                /// <param name="date"></param>
                /// <returns></returns>
                static member Create(name, date) =
                    { Name = name; Date = date}
                /// <summary>Record member example</summary>
                /// <returns></returns>
                member x.Combined =
                    $"{x.Name} - {x.Date}"
                /// <summary>Record member example</summary>
                /// <returns></returns>
                member x.Combined2 () =
                    $"{x.Name} - {x.Date}"
        
    /// <summary>Testing Hello</summary>
    /// <param name="name"></param>
    /// <returns></returns>
    let hello name =
        printfn "Hello %s" name


