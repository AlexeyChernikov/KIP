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
					<?php
						if(isset($_COOKIE['Name'])&& isset($_COOKIE['login'])){
							echo "<div class="."col-md-2"." style="."font-size:14pt;"."padding-top:25px;".">Здравствуйте,  ".$_COOKIE['Name']."!</div>";
						}
					?>
					<br><br><br><br><br><br>
					<div class="col-md-1 col-md-offset-9" style="margin-bottom: 0px;">
						<?php
							if(!isset($_COOKIE['Name'])){
								echo '<a href="reg.php" class="btn btn-primary btn-lg" role="button" aria-pressed="true">Регистрация</a>';
							}
							else if(!isset($_COOKIE['login'])){
								echo '<a href="reg.php" class="btn btn-primary btn-lg" role="button" aria-pressed="true">Войти</a>';
							}
							else{
								echo '<a href="logout.php" class="btn btn-primary btn-lg" role="button" aria-pressed="true">Выйти</a>';
							}
						?>          
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