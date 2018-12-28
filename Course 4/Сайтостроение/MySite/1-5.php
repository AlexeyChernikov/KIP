<?php
$age=17;
$result4=$result4."Значение возраста = ".$age."<br>";
if($age>=18 && $age<=35){
    $result4=$result4."Счастливчик<br>";
}else{
    $result4=$result4."Не повезло<br>";
}
if($age>=1 && $age<=17){
    $result4=$result4."Слишком молод<br>";
}
require_once("php1.html");
?>