var cvs = document.getElementById("canvas");
var ctx = cvs.getContext("2d");

var car = new Image();
var bg = new Image();
var border1 = new Image();
var border2 = new Image();
var enemy = new Image();

car.src = "img/car.png";
bg.src = "img/bg.png";
border1.src = "img/border1.png";
border2.src = "img/border2.png";
enemy.src = "img/enemy.png";

//Управление машинкой
document.onkeydown = function(e) {
    switch (e.keyCode) {
        case 37: if (xPos>=1) {xPos-=10;} break;
        case 38: if (yPos>=51) {yPos-=10;} break;
        case 39: if (xPos+car.width<=909) {xPos+=10;} break;
        case 40: if (yPos+car.height<=479-border2.height) {yPos+=10;} break;
    }
};

//Создание машин противника
var pipe = [];

pipe[0] = {
 x : cvs.width,
 y : Math.random() * (360 - 50) + 50
}

//Счёт
var score = 0;

//Позиция машинки
var xPos=100;
var yPos=220;

function draw() {
 ctx.drawImage(bg, 0, 0);
 ctx.drawImage(border1, 0, 0);
 ctx.drawImage(border2, 0, 430);
 
 ctx.drawImage(car, xPos, yPos);
 for(var i = 0; i < pipe.length; i++) {
  ctx.drawImage(enemy, pipe[i].x, pipe[i].y);
  pipe[i].x-=2;
  
  if(pipe[i].x == 750) {
   pipe.push({
    x : cvs.width,
    y : Math.floor(Math.random() * (360 - 50))+50
   });
  }
  
  // Отслеживание прикосновений
  if (xPos+car.width>=pipe[i].x && xPos <=pipe[i].x+enemy.width && (yPos <= pipe[i].y + enemy.height
   && yPos + car.height >= pipe[i].y)) {
	 location.reload();
  }
  
  if(pipe[i].x == -100) {
   score++;
  }
 }
 
  ctx.fillStyle = "#000";
  ctx.font = "24px Verdana";
  ctx.fillText("Счёт: " + score, 10, cvs.height - 15);
 requestAnimationFrame(draw);
}

enemy.onload = draw;