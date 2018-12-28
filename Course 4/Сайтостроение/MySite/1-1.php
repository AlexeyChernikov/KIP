<?php
$per1="строка";
$per2=4;
$per3=4.5;
$per4=false;
$per5=NULL;
$result="<br>Переменная 1<br>"."Название переменной: ".'per1'."<br>Cодержит: ".$per1."<br>С типом  ".gettype($per1);
$result=$result."<br>";
$result=$result."<br>Переменная 2<br>"."Название переменной: ".'per2'."<br>Cодержит: ".$per2."<br>С типом  ".gettype($per2);
$result=$result."<br>";
$result=$result."<br>Переменная 3<br>"."Название переменной: ".'per3'."<br>Cодержит: ".$per3."<br>С типом  ".gettype($per3);
$result=$result."<br>";
$result=$result."<br>Переменная 4<br>"."Название переменной: ".'per4'."<br>Cодержит: ".$per4."<br>С типом  ".gettype($per4);
$result=$result."<br>";
$result=$result."<br>Переменная 5<br>"."Название переменной: ".'per5'."<br>Cодержит: ".$per5."<br>С типом  ".gettype($per5);
require_once("php1.html");
?>
