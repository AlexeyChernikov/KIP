<?php
$min=0;
$minin=0;
$max=0;
$maxi=0;
$arr=array();
$result24="<br>Изначальный массив<br>";

for ($i=0;$i<15;$i++){
    $arr[$i]=rand(1,100);
    $result24=$result24.$arr[$i]." ";
}
$min=$arr[0];
$max=$arr[0];
for ($i=0;$i<15;$i++){
    if($max<$arr[$i]){
        $max=$arr[$i];
        $maxi=$i;
    }
    if($min>$arr[$i]){
        $min=$arr[$i];
        $minin=$i;
    }
}
$result24=$result24."<br>Минимальное значение = ".$min;
$result24=$result24."<br>Маскимальное значение = ".$max."<br>";
$arr[$maxi]=$min;
$arr[$minin]=$max;
for ($i=0;$i<15;$i++){
    $result24=$result24.$arr[$i]." ";
}
require_once("php1.html");
?>