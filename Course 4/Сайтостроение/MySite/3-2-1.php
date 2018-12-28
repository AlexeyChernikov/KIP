<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>Проверка КУКИ</title>
</head>
<body>
        <form action="3-2.php" method="POST">
            <table>
                <tr>
                    <td class="t"><label>Имя </label></td>
                    <td class="Righttable"><input type="text" name="name" /></td>
                </tr>
                <tr>
                    <td class="t"><label>Возраст</label></td>
                    <td class="Righttable"><input type="text" name="age" value=" <?php
                        $age= @$_COOKIE['age'];
                        print($age);
                        ?>"/><span>
                       
                    </span></td>
                </tr>
                <tr>
                    <td class="t"><label>Город</label></td>
                    <td class="Righttable"><input type="text" name="city" value="  <?php
                        $city= @$_COOKIE['city'];
                        echo $city;
                        ?>" /></td>
                </tr>
            </table>
            <input type="submit" name="send" value="Передать значение" class="b">
        </form>
</body>
</html>