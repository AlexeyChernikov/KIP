<!Doctype html 5>
<html>
<head>
    <meta charset="UTF-8">
    <title> Регистрация </title>
    <link href="css/bootstrap.css" rel="stylesheet">
    <link href="css/styles.css" rel="stylesheet">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">

    <style>
        body {
            background-size: cover;
            background-image: url('images/bg.jpg');
        }
    </style>
</head>
<body>
    <div class="container">
        <div >      
            <div>
            
            <div class="col-xs-12">
                <h4 class="text-justify">
                    <br>
                    <form action="chek.php" method="POST" class="col-md-5 col-md-offset-3">
                        <table class="col-md-offset-20" class="t">
                            <tr>
                                <td class="t"><label>Почта</label></td>
                                <td class="t"><input type="email" class="b" name="Login" /></td>
                            </tr>
                            <tr>
                                <td class="t"><label>Пароль</label></td>
                                <td class="t"><input type="password" class="b" name="Password" /></td>
                            </tr>

                            <?php
                            if(!isset($_COOKIE['Name'])){
                                echo"<tr><td class="."t"."><label>Имя</label></td><td class="."t"."><input type="."text"." class="."b"." name="."Name"." /></td></tr>";
                            }
                            ?>
                        </table>
						<br>
                        <input class="col-md-offset-20 btn btn-primary btn-lg" type="submit" name="send" value=<?php
                            if(!isset($_COOKIE['Name'])){
                                echo "Регистрация";
                            }
                            else{
                                echo "Войти";
                            }?> class="b">
                    </form>
					<font color="#FF0000" size="5">
                    <?php
                        echo"<br>"."<br>"."<br>"."<br>"."<br>"."<br>"."<br>"."<br> <div class="." >"."$error"."</div>";
                    ?>
                </h4>
            </div>
            <div class="col-xs-8 col-md-12">
                <ul class="list-inline">
                    <li style="margin-top: 20px;">
                        <a href="index21.php" class="btn btn-primary btn-lg" role="button" aria-pressed="true">Назад</a>
                    </li>
                </ul>
            </div>
        </div>
    </div>
    <hr>
</body>
</html>