// #Warnings
//<Expects status="Error" span="(7,13)" id="FS0001">This expression was expected to have type</Expects>

type Record = {field1:int; field2:int}
let doSomething (xs) = List.map (fun {field1=x} -> x) xs

doSomething {Record.field1=0; field2=0}
    
exit 0