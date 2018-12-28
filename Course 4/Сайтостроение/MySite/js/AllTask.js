function ex1(co1) {
    var wdsaasdr =
        "Лес-часть поверхности Земного шара, покрытая древестными растениями<br>В настоящее время леса занимают около трети площади суши<br>Площадь леса в России составляет 8млн кв.м<br>";
    co1.innerHTML = wdsaasdr;
}
function ex2(co2) {
    var wdsaasdr = "MyPASSWORD";
    co2.innerHTML = wdsaasdr;
}

function ex3(buf) {
    var sec1 = "Чер";
    var sec2 = "ни";
    var sec3 = "ко";
    var sec4 = "в";
    var bufstr="";
    bufstr = bufstr + (sec1 + sec2 + sec3 + sec4 + "<br>");
    bufstr = bufstr + (sec1 + sec2 + sec4 + sec3 + "<br>");
    bufstr = bufstr + (sec1 + sec3 + sec2 + sec4 + "<br>");
    bufstr = bufstr + (sec1 + sec3 + sec4 + sec2 + "<br>");
    bufstr = bufstr + (sec2 + sec1 + sec3 + sec4 + "<br>");
    bufstr = bufstr + (sec3 + sec2 + sec1 + sec4 + "<br>");
    bufstr = bufstr + (sec4 + sec3 + sec2 + sec4 + "<br>");
    bufstr = bufstr + (sec2 + sec4 + sec1 + sec3 + "<br>");
    bufstr = bufstr + (sec2 + sec1 + sec3 + sec4 + "<br>");
    buf.innerHTML = bufstr;
}
function ex4(vex4, vex41) {
    var x = 3, y = 20;
    var oo = (35 * y + 25 * x) / 5 + 232;
    vex4.innerHTML = oo.toString();
    x = 16;
    oo = (188 * y / 8 + 25 * x / 5 - 435) * 6;
    vex41.innerHTML = oo.toString();

}
function ex5(vex5) {
    var x = 32;
    var y = 4;
    var s = "";
    if ((x / 8 == y) && (x > 16) && (y < 5) && (y != 3))
        s = "Вы подобрали правильные значения x и y <br>Поздравляем!<br>";
    else
        s = "Значения x и y не подходят!<br>";
    vex5.innerHTML = s;
}
function ex6(vex6) {
    var s = "";
    var var1 = 7;
    var var2 = 10;
    var var3 = 8;
    var var4 = 25;
    var var5 = 30;
    if (var1 == 25) {
        s = s + "А";
    }
    if (var1 > 15) {
        s = s + "Ж";
    }
    if (var1 < 33) {
        s = s + "К";
    }
    if (var2 == 10) {
        s = s + "А";
    }
    if ((var1 + var2) == 30) {
        s = s + "Д";
    }
    if ((var2 - var1) == 7) {
        s = s + "Ш";
    }
    if (var3 < 6) {
        s = s + "М";
    }
    if (var3 == 8 && (var1 + var2) == 17) {
        s = s + "З";
    }
    if ((var1 + var2) == (var3 - var2)) {
        s = s + "Н";
    }
    if (var4 == (var1 + var2 + var3)) {
        s = s + "А";
    }
    if (var4 > ((var2 - var3) * 4)) {
        s = s + "Н";
    }
    if (var5 == var1 * 4) {
        s = s + "Б";
    }
    if (var5 == var2 * 3) {
        s = s + "Ь";
    }
    if (((var1 + var2 + var3 + var4 + var5) / 3) > 60) {
        s = s + "А";
    }
    vex6.innerHTML = s;
}
function ex7() {
    do {
        var x = prompt("Введите имя", "Заполнитель поля ввода");
        var x1 = confirm("Вы уверены что ваше имя " + x);
        if (x1 == true) {
            confirm("Приветсвуем " + x + " на нашем сайте");
            boo = true;
        }
        else {
            confirm("НЕ Повезло");
        }
    } while (boo != true);
    boo = false;
    do {
        var PrePass = prompt("Введите Пароль", "Заполнитель пароль");
        if (pass == PrePass) {
            confirm("Пароль верен");
            boo = true;
        }
        else {
            confirm("НЕ правильно");
        }
    } while (boo != true);
}
function ex8(buf) {
    var i = 100;
    var bufstr="";
    bufstr=("Число " + i + "<br>");
    do {
        i = i - 4;
        bufstr=bufstr+("Число " + i + "<br>");
    }
    while (i > 0);

    buf.innerHTML = bufstr;
}
function ex9(buf) {
    var n = 10;
    var mas = [n];
    var i1, min = 0, max = 100;
    var bufstr="";
    bufstr=("Задание 3 вывод изначального массива<br>");
    for (i1 = 0; i1 < 10; i1++) {
        mas[i1] = min - 0.5 + Math.random() * (max - min + 1)
        bufstr=bufstr+(Math.round(mas[i1]) + ",  ");
    }
    bufstr=bufstr+("<br>Вывод отсортированного массива<br>");
    for (var i = 0; i < n - 1; i++) {
        for (var j = 0; j < n - 1 - i; j++) {
            if (mas[j + 1] < mas[j]) {
                var t = mas[j + 1];
                mas[j + 1] = mas[j];
                mas[j] = t;
            }
        }
    }
    for (i1 = 0; i1 < 10; i1++) {
        bufstr=bufstr+(Math.round(mas[i1]) + ",  ");
    }

    buf.innerHTML = bufstr;
}