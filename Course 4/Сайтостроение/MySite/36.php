<?php
$answer1=$_POST['radiochoise_answer1'];
$answer2=$_POST['radiochoise_answer2'];
setcookie('answer1',$answer1);
setcookie('answer2',$answer2);
$resultstr36="Вы ответили";
require_once("php2.php");
?>