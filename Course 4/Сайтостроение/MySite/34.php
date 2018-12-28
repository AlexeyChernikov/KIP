<?php
if(!isset($_COOKIE['timer']))
{
    setcookie("timer",1,time()+300);
                            
    $resultString34="<img src="."img/foto/1.jpg"." class="."image-center"." class="."img-responsive"." width="."50%"." >";
}else{
    $resultString34="Не показываю";
}
require_once("php2.php");
?>