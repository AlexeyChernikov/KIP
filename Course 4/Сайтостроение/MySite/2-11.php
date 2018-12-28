<?php
$Godkit=$_POST['Godkit'];
$result211="Вы ввели ".$Godkit;
$start = 1924;
if ($Godkit > $start) 
    $result211=$result211."<br>". array("Крыса","Бык","Тигр","Кролик","Дракон","Змея","Лошадь","Овца","Обезьяна","Петух","Собака","Свинья")[($Godkit - $start) % 12];
else $result211=$result211."<br> Вы ввели значение меньше 1924";
require_once("php1.html");
?>