// #Warnings
//<Expects status="Error" id="FS0001">All branches of an 'if' expression must have the same type. This expression was expected to have type 'string', but here has type 'int'.</Expects>

let test = 100
let f x = test
let y =
    if test > 10 then "test"
    else f 10
    
exit 0
