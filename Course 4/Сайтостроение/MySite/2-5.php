<?php
$pro=1;
$arr=array();
$result25="<br>Заданный массив массив<br>";
for ($i=0;$i<15;$i++){
    $arr[$i]=rand(1,100);
    $result25=$result25.$arr[$i]." ";
    if($arr[$i]>0 && $i%2==0){
        $pro*=$arr[$i];
    }elseif($arr[$i]>0 && $i%2!=0){
        $bufstr=$bufstr.$arr[$i]." ";
    }
}
$result25=$result25."<br>Произведение элементов с нечетным индексом = ".$pro."<br> Элементы с нечетным индесом<br>".$bufstr;
require_once("php1.html");
?>