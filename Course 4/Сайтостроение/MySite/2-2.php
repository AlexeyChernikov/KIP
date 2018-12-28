<?php
$str=$_POST['string'];
$sub=$_POST['isk'];
$result21="В числе ".$str." число =  ".$sub." встречается " .substr_count($str,$sub). " раз(а)";
require_once("php1.html");
?>