function exersi1(buf){
    var x1=34*Math.pow(Math.PI,2)+2*Math.pow(Math.E,8);
    var x2=Math.cos(2)+Math.cos(12)+8*Math.pow(Math.PI,3);
    var x3=Math.sin(10)+15*Math.pow(Math.E,3);
    var x4=Math.pow(39,0.5)+32*Math.pow(Math.PI,0.5)+Math.tan(3);
    var bufstr="";
    if(x1>x2 && x1>x3 && x1>x4){
        bufstr=" Число из 1 формулы больше всех и равно "+x1;
    }
    if(x2>x1 && x2>x3 && x2>x4){
        bufstr=" Число из 2 формулы больше всех и равно "+x2;
    }
    if(x3>x1 && x3>x2 && x3>x4){
        bufstr=" Число из 3 формулы больше всех и равно "+x3;
    }
    if(x4>x1 && x4>x2 && x4>x3){
        bufstr=" Число из 3 формулы больше всех и равно "+x4;
    }
    buf.innerHTML = bufstr;
}
function exersi2(buf){
    var x1=Math.pow((48/3*Math.PI+308/4*Math.E),2)-203*Math.sin(5)+Math.pow((10*Math.PI-3*Math.E),3);
    var x2=Math.pow(Math.cos(20)-Math.cos(3)+Math.tan(50),0.5)-203/Math.sin(2);
    var x3=Math.pow((22*Math.PI/22*Math.E-Math.sin(3)*Math.tan(4)-34),10);
    var bufstr="";  
    var xr1=Math.round(x1);
    var xr2=Math.round(x2);
    var xr3=Math.round(x3);
    var min=0;
    var c=0;
    if(xr1<xr2 && x1<xr3 ){
        min=xr1;
        c=1
    }
    if(xr2<xr1 && xr2<xr3 ){
        min=xr2;
        c=2;
    }
    if(xr3<xr2 && xr3<xr1 ){
        min=xr3;
        c=3;
    }
    bufstr="Минимальное округленное значение получается в функции "+c+" и равно "+min;
    buf.innerHTML = bufstr;
}