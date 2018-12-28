<?php
$perem1=5.4;
$perem2=4.5;
$result3=$result3."Значение переменной 1:".$perem1."<br>";
$result3=$result3."Значение переменной 2:".$perem2."<br>";
if($perem1==$perem2){
    $result3=$result3."При сравнивание  $perem1 == $perem2: Результат правда<br>";
}else{
    $result3=$result3."При сравнивание  $perem1 == $perem2: Результат ложь<br>";
}
if($perem1===$perem2){
    $result3=$result3."При сравнивание  $perem1 === $perem2: Результат правда<br>";   
}else{
    $result3=$result3."При сравнивание  $perem1 === $perem2: Результат ложь<br>";       
}
if($perem1<>$perem2){
    $result3=$result3."При сравнивание  $perem1 <> $perem2: Результат правда<br>";
}else{
    $result3=$result3."При сравнивание  $perem1 <> $perem2: Результат ложь<br>";
}
if($perem1!=$perem2){
    $result3=$result3."При сравнивание  $perem1 != $perem2: Результат правда<br>";    
}else{
    $result3=$result3."При сравнивание  $perem1 != $perem2: Результат ложь<br>";    
}
if($perem1!==$perem2){
    $result3=$result3."При сравнивание  $perem1 !== $perem2: Результат правда<br>";    
}else{
    $result3=$result3."При сравнивание  $perem1 !== $perem2: Результат ложь<br>";    
}
if($perem1<$perem2){
    $result3=$result3."При сравнивание  $perem1 < $perem2: Результат правда<br>";    
}else{
    $result3=$result3."При сравнивание  $perem1 < $perem2: Результат ложь<br>";    
}
if($perem1>$perem2){
    $result3=$result3."При сравнивание  $perem1 > $perem2: Результат правда<br>";    
}else{
    $result3=$result3."При сравнивание  $perem1 > $perem2: Результат ложь<br>";    
}
if($perem1<=$perem2){
    $result3=$result3."При сравнивание  $perem1 <= $perem2: Результат правда<br>";
}else{
    $result3=$result3."При сравнивание  $perem1 <= $perem2: Результат ложь<br>";
}
if($perem1>=$perem2){
    $result3=$result3."При сравнивание  $perem1 >= $perem2: Результат правда<br>";
}else{
    $result3=$result3."При сравнивание  $perem1 >= $perem2: Результат ложь<br>";
}
require_once("php1.html");
?>