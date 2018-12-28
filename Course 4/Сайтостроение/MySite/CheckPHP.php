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
    $resultString = "Ошибка при подключении к БД!" . mysqli_connect_error();
    exit();
} else {
    $resultString = "Подключение к базе состоялось!";
}
$city = trim($_POST['city']);
if($_COOKIE['work']=="LOSE"){
    $resultString = "Вы выйграли! Начните новую игру!";
    exit();
}
else if ($city == "") {
    $resultString = "Вы не заполнили город!";
    exit();
} else {

    if(isset($_COOKIE['work'])){
        $BUKVA = substr($city, 0, 2);
        $BUKVA = mb_strtolower($BUKVA, 'UTF-8');
        $ff    = $_COOKIE['work'];
        if ($BUKVA != $ff) {
            $resultString = "Введенный вами город не соответсвует  требованию(Должен начинаться с буквы'" . $ff . "'!";
            require_once("Game.php");
            exit;
        }
    }
   
    $id    = 0;
    $query = sprintf("SELECT id,Name FROM City WHERE Name = '%s'", mysqli_real_escape_string($link, $city));
    $voo   = false;
    $result = mysqli_query($link, $query) or $voo = true;
    if ($voo) {
        $resultString = ("Произошла ошибка при работе с БД! " . mysqli_error($link));
        require_once("Game.php");
        exit;
    }
    if (mysqli_num_rows($result)) {
        $row = mysqli_fetch_array($result);
        $id  = $row['id'];
    } else {
        $resultString = "Извините, в нашей базе данных нету города который Вы ввели";
        require_once("Game.php");
        exit;
    }
    if (!isset($_COOKIE['work'])) {
        
        $query = "CREATE TABLE `second`.`UseCity` ( `id` INT NOT NULL AUTO_INCREMENT , `idCity` INT NOT NULL , PRIMARY KEY (`id`)) ENGINE = InnoDB;";
        $result = mysqli_query($link, $query) or $voo = true;
        $query = "INSERT INTO UseCity (idCity) VALUES ('$id')";
        $result = mysqli_query($link, $query) or $voo = true;
        if ($voo) {
            $resultString = ("Произошла ошибка при работе с БД! " . mysqli_error($link));
            require_once("Game.php");
            exit;
        }
        
    } else {
        $query = sprintf("SELECT id FROM UseCity WHERE idCity = '%s'", mysqli_real_escape_string($link, $id));
        $result = mysqli_query($link, $query) or $voo = true;
        if (mysqli_num_rows($result)) {
            $ff    = $_COOKIE['work'];
            $resultString = "Данный город уже был использован! ";
            $resultString =$resultString. "<br>Введенный вами город не соответсвует  требованию ( Должен начинаться с буквы'" . $ff . "'!)";
            require_once("Game.php");
            exit;
        } else {
            $query = "INSERT INTO UseCity (idCity) VALUES ('$id')";
            $result = mysqli_query($link, $query) or $voo = true;
        }
        if ($voo) {
            $resultString = ("Произошла ошибка при работе с БД! " . mysqli_error($link));
            require_once("Game.php");
        }
    }
    $dlina = strlen($city);
    $BUKVA = substr($city, $dlina - 2);
    
    if ($BUKVA == "ь") {
        $BUKVA = substr($city, $dlina - 4, 2);
    } else if ($BUKVA == "ы") {
        $BUKVA = substr($city, $dlina - 4, 2);
    } else if (substr($city, $dlina - 4, 2) == "ы" && substr($city, $dlina - 2) == "ь") {
        $BUKVA = substr($city, $dlina - 6, 2);
    }
    if (substr($city, $dlina - 2) == "й" ) {
        $BUKVA = substr($city, $dlina - 4, 2);
    }
    $BUKVA = $BUKVA . "%";
    $query = sprintf("SELECT id,Name FROM City WHERE Name LIKE '%s'", mysqli_real_escape_string($link, $BUKVA));
    $result = mysqli_query($link, $query) or $voo = true;
    if ($voo) {
        $resultString = ("Произошла ошибка при работе с БД! " . mysqli_error($link));
        require_once("Game.php");
        exit;
    }
    $t        = false;
    $col      = $result->num_rows;
    $CityCOMP = "";
    $pro=rand(1,1000);
    if($pro>974){
        $resultString = ("Компьютер проиграл ");
        require_once("Game.php");
        SetCookie('work', "LOSE");
        exit;
    }
    do {
        $int1 = rand(1, $col);
        $result->data_seek($int1);
        $row    = $result->fetch_assoc();
        $idComp = $row['id'];
        $query1 = sprintf("SELECT id FROM UseCity WHERE idCity = '%s'", mysqli_real_escape_string($link, $idComp));
        $result2 = mysqli_query($link, $query1) or $voo = true;
        if (!mysqli_num_rows($result2)) {
            $query = "INSERT INTO UseCity (idCity) VALUES ('$idComp')";
            $result = mysqli_query($link, $query) or $voo = true;
            $t        = true;
            $CityCOMP = $row['Name'];
            
        }
        if ($voo) {
            $resultString = ("Произошла ошибка при работе с БД! " . mysqli_error($link));
            require_once("Game.php");
            exit;
        }
    } while ($t != true);  
    $dlina = strlen($CityCOMP); 
    $BUKVA = substr($CityCOMP, $dlina - 2);
    if ($BUKVA == "ь") {
        $BUKVA = substr($CityCOMP, $dlina - 4, 2);
    } else if ($BUKVA == "ы") {
        $BUKVA = substr($CityCOMP, $dlina - 4, 2);
    } else if (substr($CityCOMP, $dlina - 4, 2) == "ы" && substr($CityCOMP, $dlina - 2) == "ь") {
        $BUKVA = substr($CityCOMP, $dlina - 6, 2);
    }
    if (substr($city, $dlina - 2) == "й" ) {
        $BUKVA = substr($city, $dlina - 4, 2);
    }
    $BUKVA = mb_strtolower($BUKVA, 'UTF-8');
    SetCookie('work', $BUKVA);
    
    $resultString = "Компьютер выбрал город '" . $CityCOMP . "'!";
    
    require_once("Game.php");
}

?>