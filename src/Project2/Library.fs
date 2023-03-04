﻿namespace Project2

module Say =
    /// <summary>Testing 2</summary>
    /// <param name="name">The name to say hello to</param>
    /// <remarks>
    /// This is the first function generated by class lib
    /// </remarks>
    /// <example id="hello-1">
    /// <code lang="F#">
    /// hello "Jerry"
    /// hello "Newman"
    /// </code>
    /// </example>
    /// <category>Hello Names</category>
    /// <returns>a side effect</returns>
    let hello name =
        printfn "Hello %s" name


    /// <summary>Testing 2</summary>
    /// <param name="name">The name to say hello to</param>
    /// <remarks>
    /// This is the first function generated by class lib
    /// </remarks>
    /// <note>
    /// Some additional text
    /// </note>
    /// <category>Hello Names</category>
    /// <returns>a side effect</returns>
    let hello2 (foo : Project1.Say.Foo) = async {
        printfn "Hello %s" foo.Name
    }

        

    /// <summary>Testing 2</summary>
    /// <param name="name">The name to say hello to</param>
    /// <remarks>
    /// </remarks>
    /// <example id="hello-1">
    /// <code lang="F#">
    /// goodbye "Jerry"
    /// goodbye "Newman"
    /// </code>
    /// </example>
    /// <category>Goodbye</category>
    /// <returns>a side effect</returns>
    let goodbye (name : Project1.Say.Foo) =
        printfn "Hello %s" name.Name