function Avto(color, model, year, manufact) {
    this.color = color;
    this.manufact = manufact;
    this.model = model;
    this.year = year;
    this.whatColor = function whatColor() {
        return st = ("Цвет автомобиля " + this.color);
    }
    this.autoInfo = function autoInfo() {
        var st = ""
        st = (" Модель автомобиля " + this.model);
        st = st + (" Год выпуска автомобиля " + this.year);
        st = st + (" Производитель автомобиля " + this.manufact);
        return st;
    }
}
function Driver(color, model, year, manufact, name, experience) {
    this.base = Avto;
    this.base(color, model, year, manufact);
    this.name = name;
    this.experience = experience;
    this.driverInfo = function driverInfo() {
        var st = "";
        st = st + ("Имя " + this.name);
        st = st + (" Опыт " + this.experience);
        return st;
    }
}
function constr(buf) {
    auto1 = new Avto("Красный", "Skyline", 2007, "Nissan");
    auto2 = new Avto("Черный", "Corolla", 2009, "Toyota");
    auto3 = new Avto("Синий", "Golf", 2009, "Volkswagen");
    
    var bufstr = "<br>" + "Часть один про цвет и иформацию объектах" + "<br>";
    bufstr = bufstr + auto1.whatColor() + " Для объекта 1" + "<br>";
    bufstr = bufstr + auto2.whatColor() + " Для объекта 2" + "<br>";
    bufstr = bufstr + auto3.whatColor() + " Для объекта 3" + "<br>" + "<br>";
    bufstr = bufstr + auto1.autoInfo() + " Для объекта 1" + "<br>";
    bufstr = bufstr + auto2.autoInfo() + " Для объекта 2" + "<br>" ;
    bufstr = bufstr + auto3.autoInfo() + " Для объекта 3" + "<br>" ;

    bufstr = bufstr +  "<br>" + "Часть два про наследование" +  "<br>";
    auname = new Driver("Белый", "Focus", 2010, "Ford", "Дмитрий", 3);
    bufstr = bufstr + auname.whatColor() + "<br>" + auname.autoInfo() + "<br>" + auname.driverInfo() + "<br>";
    buf.innerHTML = bufstr;

}