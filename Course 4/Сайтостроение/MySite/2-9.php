<?php
$god=$_POST['God'];
$result29="Вы ввели ".$god."<br>";
if($god%4==0||($god%100!=0 && $god%400==0)){
    $result29=$result29."Год является високосным";
}else{
    $result29=$result29."Год является не високосным";
}
require_once("php1.html");
?>