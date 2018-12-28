<?php
$backgroundColor=$_POST['background'];
$ReferenceColor=$_POST['ssilka'];
setcookie('backgroundColor',$backgroundColor);
setcookie('ReferenceColor',$ReferenceColor);
$resultString="Задан цвет фона ".$backgroundColor." и ссылки ".$ReferenceColor;
require_once("php2.php");
?>