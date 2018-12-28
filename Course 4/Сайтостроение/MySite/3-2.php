<?php
$name=$_POST['name'];
$age=$_POST['age'];
$city=$_POST['city'];
setcookie('name',$name);
setcookie('age',$age);
setcookie('city',$city);
$resultString1="Заданы значения ";
require_once("php2.php");
?>