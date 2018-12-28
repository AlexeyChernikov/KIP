<?php
if (isset($_COOKIE['Time']))   
{   
    
    $ge=$_COOKIE['Time'];
    $resultstr9="Прошло секунд ".(time()-$ge);

}
else{

    setcookie('Time',time());
    $resultstr9= $resultstr9."Первое посещение";

}
require_once("php2.php");
?>