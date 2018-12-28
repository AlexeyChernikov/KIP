<?php
if(!isset($_COOKIE['Corzina']))
{
setcookie('Corzina', 0);
}
else
{
setcookie('Corzina', ($_COOKIE['Corzina']+$_POST['cost']);
}
//require_once("index9.html");
?>