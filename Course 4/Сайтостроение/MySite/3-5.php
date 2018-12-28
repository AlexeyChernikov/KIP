<?php
$day=$_POST["day"];
setcookie('date',$day);
$resultString5="Заданы значения ".$_POST["day"];
require_once("index9.php");
?>