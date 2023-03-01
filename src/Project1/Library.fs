namespace Project1

module Say =
    type Foo = { Name : string}
    /// <summary>Testing Hello</summary>
    /// <param name="name"></param>
    /// <returns></returns>
    let hello name =
        printfn "Hello %s" name
