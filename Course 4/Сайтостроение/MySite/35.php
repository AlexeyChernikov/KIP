<?php
$day=$_POST["day"];
if($day!=""){
    setcookie('date',$day);
    $resultString5="Заданы значения ".$_POST["day"];
}else{
    $resultString5="НЕ задано значение";
}
require_once("php2.php");
?>