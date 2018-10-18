window.onload = function () {

    function cal(id, _input) {
        this.inputX = document.getElementById(_input);
        this.Date;
        this.id = id;
        this.now = new Date();
        this.week = ["Вс", "Пн", "Вт", "Ср", "Чт", "Пт", "Сб"];
        this.month = ["Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь"];
        this.cl = false;
        return this;
    }
    cal.prototype = {
        GetWeek: function (evt) {
            return this.week[evt.getDay()];
        },
        GetMonth: function (evt) {
            return this.month[evt];
        },
        GetCntDay: function (year, month) {
            var date = new Date(year, month + 1, 0);
            return date.getDate();
        },
        GetFirstDayOfMonth: function (evt) {
            var FD = new Date(evt);
            FD.setDate(1);
            return FD;
        },
        tdclick: function (evt) {

            var m = evt.getMonth() + 1;
            if (m < 10)
                m = "0" + m;
            var d = evt.getDate()
            if (d < 10)
                d = "0" + d;
            this.inputX.value = d + "." + m + "." + evt.getFullYear();
        },
        click: function (evt) {
            this.Date = evt;
            if (this.Date == "Invalid Date") {
                alert("Ошибка. Некорректно введены данные! Установлена текущая дата.");
                this.Date = new Date();
            }
            var div = document.createElement("div");
            var b1 = document.createElement("button");
            var b2 = document.createElement("button");

            div.className = "div2";

            b1.className = "btn btn-light btn-xs";
            b1.textContent = ">";
            b2.className = "btn btn-light btn-xs";
            b2.textContent = "<";

            var sp3 = document.createElement("span");
            sp3.id = "sp3";

            var DateNow = new Date();
            var m = this.GetMonth(DateNow.getMonth());
            if (m == this.month[2] || m == this.month[7])
                m += "a";
            else {
                m += "я";
            }
            sp3.textContent = this.Date.getFullYear() + " г.";

            b1.id = "b1";
            var self = this;
            b1.onclick = function () {
                document.getElementById("cl" + self.id).removeChild(document.getElementById("cl" + self.id).lastChild);
                self.click(new Date(self.Date.getFullYear(), self.Date.getMonth() + 1, self.Date.getDate()));
            }
            b2.id = "b2";
            b2.onclick = function () {
                document.getElementById("cl" + self.id).removeChild(document.getElementById("cl" + self.id).lastChild);
                self.click(new Date(self.Date.getFullYear(), self.Date.getMonth() - 1, self.Date.getDate()));
            }
            var idtd = 0;
            for (var q = 1; q < 3; q++) {
                var sp = document.createElement("span");
                sp.id = "sp" + q;
                var w;
                var dtg;
                if (q == 1) {
                    w = this.GetFirstDayOfMonth(this.Date).getDay() - 1;
                    sp.textContent = this.GetMonth(this.Date.getMonth());
                    dtg = this.Date;
                }
                else {
                    w = this.GetFirstDayOfMonth(new Date(this.Date.getFullYear(), this.Date.getMonth() + 1, this.Date.getDate())).getDay() - 1;
                    sp.textContent = this.GetMonth(this.Date.getMonth() + 1);
                    dtg = new Date(this.Date.getFullYear(), this.Date.getMonth() + 1, this.Date.getDate());
                }
                if (sp.textContent == "")
                    sp.textContent = "Январь";
                if (w == -1) {
                    w = 6;
                }
                var b = document.createElement("table");
                b.id = "table" + q;
                var td;
                var cn = 1;
                var d = 1;
                for (var j = 0; j < 6; j++) {
                    tr = b.appendChild(document.createElement('tr'));
                    for (var i = 0; i < 7; i++) {
                        if (j == 0) {
                            td = document.createElement('td');
                            td.className = "tr1";
                            td.textContent = this.week[i + 1];
                            if (i == 6)
                                td.textContent = this.week[0];
                        }
                        else {
                            if (cn - 1 >= w && d <= this.GetCntDay(dtg.getFullYear(), dtg.getMonth())) {
                                td = document.createElement('td');
                                td.textContent = d;
                                if (d == DateNow.getDate() && dtg.getFullYear() == DateNow.getFullYear() && dtg.getMonth() == DateNow.getMonth()) {
                                    td.className = "now";
                                }
                                var self = this;
                                let dd = d;
                                let dtgg = dtg;
                                let tdd = td;
                                td.onclick = function () {
                                    self.tdclick(new Date(dtgg.getFullYear(), dtgg.getMonth(), dd));
                                    document.getElementById("cl" + self.id).removeChild(document.getElementById("cl" + self.id).lastChild);
                                    self.cl = false;
                                }
                                td.onmouseover = function () {
                                    tdd.className += " over";
                                }
                                td.onmouseout = function () {
                                    tdd.classList.remove("over");
                                }
                                d++;
                            }
                            else {
                                td = document.createElement('td');
                                td.textContent = " ";
                                var self = this;
                            }
                            cn++;
                        }
                        tr.appendChild(td);
                    }
                }
                div.appendChild(sp);
                div.appendChild(b);
            }
            div.appendChild(sp3);
            div.appendChild(b1);
            div.appendChild(b2);
            document.getElementById("cl" + this.id).appendChild(div);

            for (var t = 0; t < idtd; t++) {
                var _self = this;
                document.getElementById(t).onclick = function () {
                    _self.tdclick();
                }
            }

        },
        RegCal: function (evt) {
            var self = this;
            document.getElementById(this.id).onclick = function () {
                if (self.cl == false) {
                    var split = self.inputX.value.split(".");
                    if (split == "") {
                        var d = new Date();
                    }
                    else {
                        var d = new Date(split[2], split[1] - 1, split[0]);
                    }
                    self.click(d);
                    self.cl = true;
                }
                else {
                    document.getElementById("cl" + self.id).removeChild(document.getElementById("cl" + self.id).lastChild);
                    self.cl = false;
                }
            };
        }
    }
    var dt = new Date();
    var month = dt.getMonth() + 1;
    var day = dt.getDate();
    if (day < 10)
        day = "0" + day;
    if (month < 10)
        month = "0" + month;

    var c = new cal("1", "input");
    c.RegCal();

    var c2 = new cal("2", "input2");
    c2.RegCal();
}
