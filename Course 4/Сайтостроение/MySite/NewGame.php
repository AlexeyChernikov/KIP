<?php
$sqlhost = "localhost";
$sqluser = "root";
$sqlpass = "";
$db      = "second";
header('Content-Type:text/html;charset=utf-8');
$link = mysqli_connect($sqlhost, $sqluser, $sqlpass, $db) or $resultString = ("MySQL не доступен! " . mysqli_error());
if (!$link)
    die("Ошибка при подключении к базе данных");
if (mysqli_connect_error()) {
    $resultString1 = "Ошибка при подключении к БД!" . mysqli_connect_error();
    exit();
} else {
    $resultString1 = "Уже новая игра";
}
    SetCookie('work','');
    $query = "DROP TABLE UseCity";
    $voo   = false;
    $result = mysqli_query($link, $query) or $voo = true;
    if ($voo) {
        $resultString = ("Произошла ошибка при работе с БД! " . mysqli_error($link));
        require_once("Game.php");
        
        exit;
    }
    $resultString1 = "Новая игра начата";
    require_once("Game.php");
require_once("Game.php");
?>