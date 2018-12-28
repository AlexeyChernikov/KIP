<!DOCTYPE html>
<html>
  <head>
    <title>Сайтостроение</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link href="css/styles.css" rel="stylesheet">
	<link href="css/main.css" rel="stylesheet">
	<style>
        body {
            background-size: cover;
            background-image: url('images/bg.jpg');
        }
    </style>
  </head>
  
  <body>
  
	<script src="js/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script> 
	
	<!-- Верхнее меню -->
	
	<div class="wrapper container">
		<nav class="navbar navbar-default">
			<ul class="nav navbar-nav">
				<li><a href="index21.php">Регистрация</a></li>  
				<li class="dropdown"><a href="#" data-toggle="dropdown" class="dropdown-toggle">Сайт<b class="caret"></b></a>
					<ul class="dropdown-menu">
                        <li><a href="index.html">Главная</a></li>
                        <li><a href="story.html">Сюжет игры</a></li>
                        <li><a href="development.html">Разработка игры</a></li>
                        <li><a href="gamemusic.html">Музыка</a></li>
                        <li><a href="systemrequirement.html">Системные требования</a></li>
                    </ul>
				</li>
				<li class="dropdown"><a href="#" data-toggle="dropdown" class="dropdown-toggle">PHP<b class="caret"></b></a>
                    <ul class="dropdown-menu">
                        <li><a href="php1.html">PHP 1</a></li>
                        <li><a href="php2.html">PHP 2</a></li>
                    </ul>
				</li>
				<li><a href="js.html">JS</a></li>
				<li><a href="canvas.html">CANVAS</a></li>
				<li class="dropdown"><a href="#" data-toggle="dropdown" class="dropdown-toggle">Игры<b class="caret"></b></a>
                    <ul class="dropdown-menu">
						<li><a href="Race.html">Игра "Race!" на JS</a></li>
                        <li><a href="Game.php">Игра "Города" на PHP</a></li>
                    </ul>
				</li> 
			</ul>
		</nav>
		
		<!-- Граница -->
		
		<div class="heading">
			<center><h1></h1></center>
		</div>
		
		<!-- Основная часть -->
		
		<div class="row">
		
		<!-- Правое меню -->
		
			<aside class="col-md-7">
				<ul class="list-group submenu">
					<li class="list-group-item"><a href="index21.php">Регистрация</a></li>
					<li class="dropdown list-group-item"><a href="#" data-toggle="dropdown" class="dropdown-toggle">Сайт<b class="caret"></b></a>
						<ul class="dropdown-menu">
							<li><a href="index.html">Главная</a></li>
							<li><a href="story.html">Сюжет игры</a></li>
							<li><a href="development.html">Разработка игры</a></li>
							<li><a href="gamemusic.html">Музыка</a></li>
							<li><a href="systemrequirement.html">Системные требования</a></li>
						</ul>
					</li>
					<li class="dropdown list-group-item"><a href="#" data-toggle="dropdown" class="dropdown-toggle">PHP<b class="caret"></b></a>
						<ul class="dropdown-menu">
							<li><a href="php1.html">PHP 1</a></li>
							<li><a href="php2.html">PHP 2</a></li>
						</ul>
					</li>
					<li class="list-group-item"><a href="js.html">JS</a></li>
					<li class="list-group-item"><a href="canvas.html">CANVAS</a></li>
					<li class="dropdown list-group-item"><a href="#" data-toggle="dropdown" class="dropdown-toggle">Игры<b class="caret"></b></a>
						<ul class="dropdown-menu">
							<li><a href="Race.html">Игра "Race!" на JS</a></li>
							<li><a href="Game.php">Игра "Города" на PHP</a></li>
						</ul>
					</li>
				</ul>
			</aside>
			
			<!--Текст -->
			
			<section class="col-md-17">
				<div style="border: 0.1px solid Silver; background: #f3f3f3;">
					<font size="6"><center>Задание</center></font>
					<p align="justify"><font color="#8f8f8f" size="4">
					Написать игру "Города" на языке PHP.
					</p>
				</div>
				<br>
                <div style="border: 0.1px solid Silver; background: #f3f3f3;">
					<font size="6"><center>Игра в города</center></font>
					<h4 class="text-justify">
                    <form action="CheckPHP.php" method="POST">
                        <table>
                            <tr>
                                <td class="t"><label>Укажите город</label></td>
                                <td class="Righttable"><input type="text" class="b" name="city" /></td>                               
                            </tr>
                        </table>
                        <input type="submit" name="send" value="Проверить" class="b">
                    </form>
                    <span>
                        <?php echo $resultString;?>
                    </span>
                    <form action="NewGame.php" method="POST">
                        <input type="submit" name="send" value="Новая Игра" class="b">
                    </form>
                    <span>
                        <?php echo $resultString1;?>
                    </span>
                    <?php
                        if (isset($_COOKIE['work'])) {
                            $sqlhost = "localhost";
                            $sqluser = "root";
                            $sqlpass = "";
                            $db      = "second";
                            $link = mysqli_connect($sqlhost, $sqluser, $sqlpass, $db) or $resultString = ("MySQL не доступен! " . mysqli_error());
                            if (!$link)
                                die("Ошибка при подключении к базе данных");
                            if (mysqli_connect_error()) {
                                $resultString = "Ошибка при подключении к БД!" . mysqli_connect_error();
                                exit();
                            } else {
                                $resultString = "Подключение к базе состоялось!";
                            }
                            $query = "SELECT UseCity.id, City.Name FROM UseCity, City WHERE UseCity.idCity=City.id";
                            $result = mysqli_query($link, $query) or $voo = true;
                            if ($voo) {
                                $resultString = ("Произошла ошибка при работе с БД! " . mysqli_error($link));
                                require_once("Game.php");
                                exit; 
                            }
                            $t        = false;
                            $col      = $result->num_rows;
                            $s="";
                            $s1="";                         
                            echo $s;
                        }                        
                    ?>
					</h4>
				</div>
			</section>
		</div>
	</div>
	
	<!-- Подвал -->
	
	<footer>
		<div class="container" style="">
			<div class="row">
				<div>
					<br><br><br>
					<center><a href="https://vk.com/tamseler99"><h3>Черников Алексей 2018</h3></a>
				</div>
			</div>
		</div>
	</footer>
	
	<script src="js/jquery.min.js"></script>
	
  </body>
</html>