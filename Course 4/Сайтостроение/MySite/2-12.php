<?php
$n=ltrim($_POST['N']);
$result212="Вы ввели ".$n."<br>Квадраты: ";
$sum=0;
$sumkv=0;
for($i=1;$i<=$n;$i++){
    $sum=$sum+(pow($i,$i));
    $sumkv=$sumkv+pow($i,2);
    $result212=$result212." ".pow($i,2);
}
$result212=$result212."<br>Сумма квадратов = ". $sumkv;
$result212=$result212."<br>Сумма по условию= ". $sum;
require_once("php1.html");
?>