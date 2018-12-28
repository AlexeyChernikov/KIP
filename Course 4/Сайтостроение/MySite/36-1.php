<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>Работа с куки</title>
</head>
<body>
    <form action="36.php" method="POST">
        <label>Год основания Москвы</label><br>
        </td><input type="radio" name="radiochoise_answer1" value="1" <?php if($_COOKIE['answer1']=="1") echo "checked"?> /><label>1945</label><br>
        <input type="radio" name="radiochoise_answer1" value="2"  <?php if($_COOKIE['answer1']=="2") echo "checked"?> /><label>1147</label><br>
        <input type="radio" name="radiochoise_answer1" value="3" <?php if($_COOKIE['answer1']=="3") echo "checked"?> /><label>998</label><br>
        <input type="radio" name="radiochoise_answer1" value="4" <?php if($_COOKIE['answer1']=="4") echo "checked"?>/><label>1601</label><br>

        <label>Год крещения</label><br>
        </td><input type="radio" name="radiochoise_type" value="1" <?php if($_COOKIE['answer2']=="1") echo "checked"?> /><label>1945</label><br>
        <input type="radio" name="radiochoise_answer2" value="2" <?php if($_COOKIE['answer2']=="2") echo "checked"?> /><label>1147</label><br>
        <input type="radio" name="radiochoise_answer2" value="3" <?php if($_COOKIE['answer2']=="3") echo "checked"?> /><label>988</label><br>
        <input type="radio" name="radiochoise_answer2" value="4" <?php if($_COOKIE['answer2']=="4") echo "checked"?>/><label>1601</label><br>

        <input type="submit" name="send" value="Ответить" class="b">
    </form>
</body>
</html>