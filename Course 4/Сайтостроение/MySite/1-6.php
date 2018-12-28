<?php
$mainarray=array();
$i2=0;
for ($i=1;$i<=100;$i++){
    if($i%2===0){
        $mainarray[$i2]=$i;
        $i2++;
    }
}
for($i=0;$i<50;$i++){
    if($mainarray[$i]%5===0){
        $result5=$result5.$mainarray[$i]."<br>";
    }
}
require_once("php1.html");
?>