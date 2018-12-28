<?php
$znach=ltrim($_POST['Znach']);
$result210="Вы ввели ".$znach;
switch ($znach) {
    case '2':$result210=$result210."<br> Двойка";break;
    case '3':$result210=$result210."<br> Тройка";break;
    case '4':$result210=$result210."<br> Четверка";break;
    case '5':$result210=$result210."<br> Пятерка";break;
    case '6':$result210=$result210."<br> Шестёрка";break;
    case '7':$result210=$result210."<br> Семерка";break;
    case '8':$result210=$result210."<br> Восьмерка";break;
    case '9':$result210=$result210."<br> Девятка";break;
    case '10':$result210=$result210."<br> Десятка";break;
    case '11':$result210=$result210."<br> Валет";break;
    case '12':$result210=$result210."<br> Дама";break;
    case '13':$result210=$result210."<br> Король";break;
    case '14':$result210=$result210."<br> Туз";break;
    default:$result210=$result210."<br> Значение не подходит";break;
}
require_once("php1.html");
?>