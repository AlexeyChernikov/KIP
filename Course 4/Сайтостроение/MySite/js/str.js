function exersize1(conent1, conent2) {
    var str1 = 'В тайге и горах можно увидеть марала, лося, белку, бурундука, зайца.';
    var st1 = str1.substr(30, 19);
    conent1.innerHTML = "substr <br>" + st1;
    var st2 = str1.substring(30, 49);

    conent2.innerHTML = "substring <br>" + st2;
}
function exersize2(buf, buf2) {
    var ss = (String.fromCharCode(1052, 1086, 1089, 1082, 1074, 1072));
    buf.innerHTML = ss;
    var bufstr = "";
    for (i = 0; i < ss.length; i++) {

        bufstr = bufstr + ss.charCodeAt(i);
        bufstr = bufstr + "  ";
    }
    buf2.innerHTML = bufstr;
}

function exersize3(buf) {
    var ss1 = "Алтайские горы - представляют сложную систему самых высоких в Сибири хребтов, разделённых глубокими долинами рек и обширными внутригорными и межгорными котловинами."
    var ss2 = "Горная система расположена там, где сходятся границы России, Монголии, Китая и Казахстана."
    var ss3 = "Она делится на Южный Алтай(Юго - Западный), Юго - Восточный Алтай и Восточный Алтай, Центральный Алтай, Северный и Северо - Восточный Алтай, Северо - Западный Алтай."
    var ss4 = "Алтайский, Катунский заповедники и плоскогорье Укок в совокупности образуют объект Всемирного наследия ЮНЕСКО, именуемый « Алтай — Золотые горы»."
    var bufstr = "";
    bufstr=bufstr+"'Алтайские' с индексом "+ ss1.indexOf("Алтайские")+"<br>";
    bufstr=bufstr+"'горы' с индексом "+ ss1.indexOf("горы")+"<br>";
    bufstr=bufstr+"'Сибири' с индексом "+ ss1.indexOf("Сибири")+"<br>";
    bufstr=bufstr+"'Южный' с индексом "+ ss3.indexOf("Южный")+"<br>";
    bufstr=bufstr+"'Алтай' с индексом "+ ss3.indexOf("Алтай")+"<br>";
    bufstr=bufstr+"'ЮНЕСКО' с индексом "+ ss4.indexOf("ЮНЕСКО")+"<br>";
    bufstr=bufstr+"'Алтай' с индексом "+ ss4.indexOf("Алтай ")+"<br>";
    bufstr=bufstr+"'Золотые' с индексом "+ ss4.indexOf("Золотые")+"<br>";
    bufstr=bufstr+"'горы' с индексом "+ ss4.indexOf("горы")+"<br>";
    buf.innerHTML = bufstr;
}