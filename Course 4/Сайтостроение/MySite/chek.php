<?php

$sqlhost="localhost";
$sqluser="root";
$sqlpass="";
$db="pestov";
header('Content-Type:text/html;charset=utf-8');
$link=mysqli_connect($sqlhost,$sqluser,$sqlpass,$db) or die("MySQL не доступен! ".mysqli_error());
if(!$link)
    die("Ошибка при подключении к базе данных");
if(mysqli_connect_error()){
    $error="Ошибка при подключении к БД!".mysqli_connect_error();
    exit();
}
else{
    $error="Подключение к базе состоялось!";

}
if(!isset($_COOKIE['Name'])){
    $log=$_POST['Login'];
    $pas=$_POST['Password'];
    $name=$_POST['Name'];
    $query = sprintf("SELECT * FROM krill WHERE login='%s'",mysqli_real_escape_string($link,$log));
    $result=mysqli_query($link,$query) or die("Ошибка ".mysqli_error($link));
    if(mysqli_num_rows( $result)){
        $error="Извините, введеный вами логин уже существует";
        require_once("reg.php");
    }
    else{
        $query="insert into krill (login,password,name) VALUES ('$log','$pas','$name')";
        if(mysqli_query($link,$query)){
            $error="Пользователь добавлен!";
            $query = sprintf("SELECT * FROM krill WHERE login='%s'",mysqli_real_escape_string($link,$log));
            SetCookie('Name',$name,time() + (3600 * 24 * 30));
            SetCookie('login',$log);
            header("Refresh:0;url=index21.php");
            exit;
        }
        else{
            $error="Пользователь НЕ добавлен!";
        }
    }
}
else{
    $log=$_POST['Login'];
    $pas=$_POST['Password'];
    $query = sprintf("select name FROM krill WHERE login = '%s' AND password ='%s'",mysqli_real_escape_string($link,$log),mysqli_real_escape_string($link,$pas));
    $result=mysqli_query($link,$query) or die("Ошибка ".mysqli_error($link));
    if(mysqli_num_rows( $result)){
        $row=mysqli_fetch_array($result);
        SetCookie('login',$log);
        SetCookie('Name',$row['name']);
        header("Refresh:0;url=index21.php");
        exit;
    }
    else{
        $error="Введите правильный логин и пароль!";
        require_once("reg.php");
        require_once("reg.php");   
    }
}
?>