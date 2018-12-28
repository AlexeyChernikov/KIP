<?php
$chis=$_POST['Chislo'];
$chi="";
$in=0;
$strcj=strval($chis);
for($i=0;$i<strlen($strcj);$i++)
{
    $in+=$strcj[$i];
}
$result20="Из числа ".$chis." сумма чисел =  ".$in;
require_once("php1.html");
?>