<?php
$a=ltrim($_POST['Grad']);
$a = (string) round(($a * 12/360), 2);
$hour = str_split($a);
$result27="Прошло часов ".$hour[0]." ч " ;
require_once("php1.html");
?>