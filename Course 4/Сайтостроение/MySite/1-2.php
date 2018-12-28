<?php
$perem1=44;
$perem2=3;
$result1=$result1."Даны числа: ".$perem1." и ".$perem2."<br>";
$result1=$result1."Сложение: ".$perem1."+".$perem2." = ".($perem1+$perem2)."<br>";
$result1=$result1."Сложение: ".$perem2."+".$perem1." = ".($perem2+$perem1)."<br>";
$result1=$result1."Вычитание: ".$perem1."+".$perem2." = ".($perem1-$perem2)."<br>";
$result1=$result1."Вычитание: ".$perem2."+".$perem1." = ".($perem2-$perem1)."<br>";
$result1=$result1."Перемножение: ".$perem1."*".$perem2." = ".($perem1*$perem2)."<br>";
$result1=$result1."Перемножение: ".$perem2."*".$perem1." = ".($perem2*$perem1)."<br>";
$result1=$result1."Деление: ".$perem1."/".$perem2." = ".($perem1/$perem2)."<br>";
$result1=$result1."Деление: ".$perem2."/".$perem1." = ".($perem2/$perem1)."<br>";
$result1=$result1."Инкримент: ++ ".$perem1." = ".(++$perem1)."<br>";
$result1=$result1."Инкримент: ++ ".$perem2." = ".(++$perem2)."<br>";
$result1=$result1."Дикремент: -- ".$perem1." = ".(--$perem1)."<br>";
$result1=$result1."Дикремент: -- ".$perem2." = ".(--$perem2)."<br>";
require_once("php1.html");
?>