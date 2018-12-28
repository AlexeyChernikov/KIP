<?php
$birthday =$_COOKIE['date'];
$arr=explode('-',$birthday);
$tm=mktime(0,0,0,$arr[1],$arr[2],date('Y'));
if($tm<time()){
    $tm=mktime(0,0,0,$arr[1],$arr[2],date('Y')+1);
}
$res=intval(($tm-time())/86400);
if($res==364){
    $resultString51="Поздравляем с днем рождения ";
}else{
    $resultString51="У Вас День рождения ".$birthday.". До дня рождения осталось(ся) ".($res+1)." дней(ня)";
}
require_once("php2.php");
?>