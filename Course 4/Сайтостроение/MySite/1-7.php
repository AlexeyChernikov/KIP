<?php
$mainarray=array(
    'Name'=>array("Петя","Вика","Кирилл"),
    'Adress'=>array("Москва","Эстония","Латвия"),
    'Phone'=>array("89993939392","8948382858484","94846723738"),
    'Mail'=>array("Petya@mail.ru","Vika@mail.es","Kirill@mail.es"),
);
echo "<pre>"; 
printf ("%-25s%-25s%25s%25s%'=80s", "Имя", "Адрес","Телефон","Почта<br>","");
$l=0;
$i=0;
$string=array();
foreach($mainarray as $value){
    $string=null;
    $i=0;
    foreach($mainarray as $key=>$value){
         $string[$i]=$value[$l];
         $i++;  
    }

    echo "<br>"; 
    if($l<3){
        printf ("<br>"."%'.-25s%'.20s%'.22s%'%'.22s", $string[0], $string[1],$string[2], $string[3]); 
    }
    $l++;
}
echo "</pre>";
?>