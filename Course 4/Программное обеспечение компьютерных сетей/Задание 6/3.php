<?php
header('Content-Type:text/html;charset=utf-8');
$target_dir = "example/";
$target_file = $target_dir . basename($_FILES["fileToUpload"]["name"]);
$uploadOk = 1;
$imageFileType = strtolower(pathinfo($target_file,PATHINFO_EXTENSION));
if(isset($_POST["submit"])) 
{
    $check = getimagesize($_FILES["fileToUpload"]["tmp_name"]);
    if($check !== false) 
	{
        echo "Выбранный  файл - " . $check["mime"] . ".";
        $uploadOk = 1;
    } 
}
if (file_exists($target_file)) 
{
    echo "Данный файл уже существует в данной директории";
    $uploadOk = 0;
}
else
{
    if (move_uploaded_file($_FILES["fileToUpload"]["tmp_name"], $target_file))
	{
        echo "Файл был загружен '". basename( $_FILES["fileToUpload"]["name"]). "' был загружен.";
    }
	else
	{
        echo "Простите, произошла ошибка при загрузки файла.";
    }
}
