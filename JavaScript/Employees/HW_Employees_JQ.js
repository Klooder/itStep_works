$(document).ready(
    function () {


        $("button#add").on("click", function () {

            $(".opasity, #ar").show();
        });

        $(".opasity, #otm").on("click", function () {
            $(".opasity, #ar").hide();
            $("#y").remove();
            clear();
        });


        $("button#inputGroupFileAddon04").on("click", function () {
            var reader = new FileReader();
            reader.onload = function () {
                $("#imgar").attr({ "src": reader.result });
            }
            reader.readAsDataURL($("#inputGroupFile02")[0].files[0]);
        });

        $("button#dob").on("click", function () {
            dd(1, 2);
        })

        $

    }


);
var id = 0;
function rem(_id) {
    $(".opasity").show();
    $("#body").append("<div id='y', class='y'/>");
    $("#y").append("<div class='y2'>Удалить сотрудника?</div>")
    $("#y").append(" <div class='b1'><button id='yes'  type='button' class='btn btn-outline-danger'>Да</button><div>");
    $("#y").append(" <div class='b2'><button id='no' type='button' class='btn btn-outline-success'>Нет</button><div>");
    $("#yes").on("click", function () {
        $("#" + _id + "").remove();
        $("#y").remove();
        $(".opasity").hide();
    });
    $("#no").on("click", function () {
        $(".opasity").hide();
        $("#y").remove();
    })

}
function clear() {
    $("#fio").val("");
    $("#work").val("");
    $("#age").val("");
    $("#imgar").attr({ "src": "" });
}

function add(id, _p) {
    if (id == 1)
        dd(2, _p);
    else if (id == 2)
        dd(1, _p);

}
function dd(_com, _id) {
    if (_com == 1) {
        if ($("#fio").val() != "" && $("#work").val() != "" && $("#age").val() != "") {
            $("#body").append("<div id='" + id + "', class='new'/>");
            $("#" + id + "").append("<img id='l4" + id + "' src='" + $("#imgar").attr("src") + "'  class='rounded float-left im' alt='Фото'/>");
            $("#" + id + "").append("<div><label id='l1" + id + "' class='left name' >" + $("#fio").val() + "</label></div>");
            $("#" + id + "").append("<div><label id='l2" + id + "' class='left'>Должность: " + $("#work").val() + "</label></div>");
            $("#" + id + "").append("<div><label id='l3" + id + "' class='left' >Возраст: " + $("#age").val() + "</label></div>");

            $("#" + id + "").append(" <div class='rem'><button id='rem" + id + "' type='button' class='btn btn-outline-danger'>Удалить</button><div>");
            $("#" + id + "").append(" <div class='rem2'><button id='red" + id + "' type='button' class='btn btn-outline-primary'>Редактировать</button><div>");
            let dd = id;

            $("button#rem" + id + "").on("click", function () {
                rem(dd);
            });
            $("button#red" + id + "").on("click", function () {
                $(".opasity, #ar").show();
                $("#fio").val($("#l1" + dd + "").text());
                var split = $("#l2" + dd + "").text().split(":");
                $("#work").val(split[1]);
                var split2 = $("#l3" + dd + "").text().split(":");
                $("#age").val(split2[1]);
                $("#imgar").attr({"src": $("#l4" + dd + "").attr("src")});
              
                $("button#dob").off("click");
                $("button#dob").on("click", function () {
                    add(1,dd);
                });
            });

            id++;
            $(".opasity, #ar").hide();
            clear();
        }
        else {
            alert("Заполните все поля!");
        }
    }
    else if (_com == 2) {

        $("#l1" + _id + "").text($("#fio").val());
        $("#l2" + _id + "").text("Должность:"+$("#work").val());
        $("#l3" + _id + "").text("Возраст:"+$("#age").val());
        $("#l4" + _id + "").attr({ "src": $("#imgar").attr("src") });
        clear();
        $(".opasity, #ar").hide();
        $("#y").remove();

        $("button#dob").off("click");
        $("button#dob").on("click", function () {
            add(2, dd);
        });

    }
}