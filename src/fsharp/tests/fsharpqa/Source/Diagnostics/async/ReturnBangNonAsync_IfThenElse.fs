// #Regression #Diagnostics #Async 
// Regression tests for FSHARP1.0:4394
//<Expects status="error" span="(7,18-7,19)" id="FS0001">This expression was expected to have type</Expects>
async { if true then 
          return ()
        else
          return 1 } |> ignore
