<?php
if(isset($_COOKIE['login'])){
	setcookie('login',"");
}
require_once("reg.php");
?>