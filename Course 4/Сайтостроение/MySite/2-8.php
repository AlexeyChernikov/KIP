<?php
$time=ltrim($_POST['Time']);
$result28="Введенное вами значение равно ".$time."<br>";
if($time>59){
    $result28=$result28."<br>Вы ввели не корректные значения";
    require_once("php1.html");
    return;
}
$green=true;
$arr=array();
for($o=0;$o<60;$o++){
    $arr[$o]=$o;
}
for($i=0;$i<60;$i++){
    if($green==true){
        if($time>=$i && $time<=($i+2)){
            $result28=$result28."<br>Цвет зеленый";
            break;
        }
        $i+=2;
        $green=false;
    }else{
        $green=true;
        if($time>=$i && $time<=($i+1)){
            $result28=$result28."<br>Цвет красный";
            break;
        }
        $i++;
    }
}
require_once("php1.html");
?>