<?php
$fio=ltrim($_POST['FIO']);
$fio=trim($fio);
$result26="Введенное значение ".$fio;
$result26=$result26."<br>Сокращенное ФИО ";
$boo=false;
$ar=array();
$l1=0;
for($i=0;$i<strlen($fio);$i++){
    if($fio[$i]==" "){
        $ar[$l1]=$i;
        $l1++;
        $boo=true;
    }
    if(!$boo){
        $result26=$result26.$fio[$i];
    }
    
}
$result26=$result26." ".substr($fio,$ar[0],3).". ".substr($fio,$ar[1],3).". ";
require_once("php1.html");
?>