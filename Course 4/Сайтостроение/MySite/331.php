<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>Проверка КУКИ</title>
</head>
<body>
        <form action="331.php" method="POST">
            <input type="submit" name="CheckCorzina" value="Проверить корзину" class="b">
        </form> 
        <br>
        <form action="delete.php" method="POST">
            <input type="submit" name="clear" value="Очистить корзину" class="b">
        </form>   
        <br>   
        <a href="php2.html">Назад</a>
        <br>   
        <span>
            <?php echo $resuktdele ?>
        </span>
<?php
function CheckCorzina(){
 echo "В корзине товаров на сумму ".$_COOKIE['Corzina'];
}

if(isset($_POST['CheckCorzina'])){
    CheckCorzina();
}
?>
</body>
</html>