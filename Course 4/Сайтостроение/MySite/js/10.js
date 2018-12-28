var continent=[];
var bird=[];
var contbird=[];
function func1(bo,conent1){
    var country=["Пакистан","Германия","Италия","Россия","Австралия","Южная Америка","Евразия","Африка","Антарктида"];
    continent=country.slice(4,9);
    if(bo==true)
        conent1.innerHTML=continent;

}
function func2(bo,conent1){
    var animal=["Лев","Тигр","Орел","Воробей","Снегирь","Голубь","Рысь","Медведь"];
    bird=animal.slice(2,6);
    if (bo==true)
        conent1.innerHTML=bird;
}
function func3(bo,conent1){

    func1(false);
    func2(false);
    contbird=bird.concat(continent);
    if (bo==true)
        conent1.innerHTML=contbird;
}
function func4(bo,conent1){
    func3(false);
    contbird.unshift("Попугай");
    contbird.push("Северная Америка")
    if(bo==true)
        conent1.innerHTML=contbird;
}
function func5(conent1){
    func4(false);
    contbird.sort();
    conent1.innerHTML=contbird;

}