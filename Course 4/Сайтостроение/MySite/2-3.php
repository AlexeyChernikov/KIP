<?php
$count=0;
for($i=20;$i<=45;$i++){
    if($i%5==0){
        $count+=$i;
    }
}
$result23="Сумма чисел между 20-45 делящиеся на 5 = ".$count;
require_once("php1.html");
?>