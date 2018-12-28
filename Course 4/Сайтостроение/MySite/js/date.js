function exersiz1(cr5){
date =new Date(388048292221);
date1 =new Date(734019522932);
date2 =new Date(983283741123);
var bufstr="";
bufstr=bufstr+"<br>Первое число<br><br>"
bufstr=bufstr+"Год: "+date.getFullYear()+"<br>";
bufstr=bufstr+"Месяц: "+(date.getMonth()+1)+"<br>";
bufstr=bufstr+"Число: "+date.getDate()+"<br>";
bufstr=bufstr+"Время: "+date.getHours()+":"+date.getMinutes()+"<br>";
bufstr=bufstr+"<br>Второе число<br><br>"
bufstr=bufstr+"Год: "+date1.getFullYear()+"<br>";
bufstr=bufstr+"Месяц: "+(date1.getMonth()+1)+"<br>";
bufstr=bufstr+"Число: "+date1.getDate()+"<br>";
bufstr=bufstr+"Время: "+date1.getHours()+":"+date1.getMinutes()+"<br>";
bufstr=bufstr+"<br>Третье число<br><br>"
bufstr=bufstr+"Год: "+date2.getFullYear()+"<br>";
bufstr=bufstr+"Месяц: "+(date2.getMonth()+1)+"<br>";
bufstr=bufstr+"Число: "+date2.getDate()+"<br>";
bufstr=bufstr+"Время: "+date2.getHours()+":"+date2.getMinutes()+"<br>";
cr5.innerHTML = bufstr;
}