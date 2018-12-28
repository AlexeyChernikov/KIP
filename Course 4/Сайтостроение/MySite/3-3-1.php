<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>Проверка КУКИ</title>
</head>
<body>
        <form action=" 3-3-1.php" method="POST">
            <input type="submit" name="CheckCorzina" value="Проверить корзину" class="b">
        </form> 
        <br>
        <form action="" method="POST">
            <input type="submit" name="clear" value="Очистить корзину" class="b">
        </form>    
        <br>   
<?php
function CheckCorzina(){
 echo $_COOKIE['Corzina'];
}
function Error(){
    setcookie('Corzina', 0);    
}
if(isset($_POST['CheckCorzina'])){
    CheckCorzina();
}
if(isset($_POST['clear'])){
    Error();
}
?>

</body>
</html>