

//lower type = int
//higher type = string

(function(){
    var bind, unit;


    bind = function(ma, func){
        if(ma && !isNaN(ma)){
            return func(parseInt(ma, 10));
        }

        return "Not a number";
    }

    unit = function(a){
        return a.toString();
    }

    var result = bind("2", function(a){
        return bind("3", function(b){
            return bind("xyz", function(c){
                return bind("50", function(d){
                    return unit(a + b + c + d);
                })
            })
        })
    })

    var add = function(a, b){
        return a + b;
    }

    var sub = function(a, b){
        return a - b;
    }

    var add2 = function(ma, mb){
        return bind(ma, function(a){
            return bind(mb, function(b){
                return unit(add(a, b));
            })
        })
    }

    var lift2 = function(func){
        return function(ma, mb){
            return bind(ma, function(a){
                return bind(mb, function(b){
                    return unit(func(a, b));
                })
            })
        }
    }

    var add3 = lift2(add);
    var sub3 = lift2(sub);



    var res = sub3("50", add3("10", "5"));

    console.log(res);


}());
