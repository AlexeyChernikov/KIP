<?php
if(!isset($_COOKIE['counter']))
{
setcookie('counter', 1);
$resultstr8= 'Вы не обновляли еще странцу!';
}
else
{
setcookie('counter', $_COOKIE['counter']+1);
$re=$_COOKIE['counter'];
$re++;
$resultstr8 = 'Вы посетили наш сайт '.$re.' раз!';
}
require_once("php2.php");
?>