var q = false;
var res = "";
var int = 0;
function myFunction(id) {

    if (document.calc.result1.value.length <= 22 && document.calc.result.value.length <= 12) {
        if (q == true) {
            document.calc.result.value = "";
            q = false;
        } 
        var pl = document.getElementById("pl");
        pl.disabled = false;
        document.calc.result.value += id;
        res += id;
        var str = "/*-+";
        for (var i = 0; i < str.length; i++) {
            if (id == str[i]) {
                document.calc.result1.value += document.calc.result.value;
                backsp();
                q = true;
                int += 1;
                pl.disabled = true;
            }
        }

        if (int == 2) {
            res = res.substr(0, res.length - 1);
            document.calc.result.value = eval(res);
            res = eval(res) + id;
            int = 1;
        }
    }
}
function textClear() {
    document.calc.result.value = "";
    document.calc.result1.value = "";
    res = "";
    int = 0;
    q = false;
}
function result() {
    try {
        res = document.calc.result.value = eval(res);
        document.calc.result1.value = "";
    }
    catch (e) {
        document.calc.result.value = e.message;
        q = true;
    }
}
function backsp() {
    document.calc.result.value = document.calc.result.value.substr(0, document.calc.result.value.length - 1);
}
function plmn() {
    res = res.substr(0, res.length - document.calc.result.value.length - 1);
    res += document.calc.result.value = parseFloat(document.calc.result.value) * -1;
}