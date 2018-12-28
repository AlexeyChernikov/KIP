<?php
session_start();
if (!isset($_SESSION['znach1'])) {
    $arr=array();
    $arr[0]=-1;
    $arr[1]=-1;
    $arr[2]=-1;
    $arr[3]=-1;
    $arr[4]=-1;
    $arr[4]=-1;
    $_SESSION['znach1'] = $arr;
  } 
  else 
  {
    $arr1=$_SESSION['znach1'];

    for($i=0;$i<6;$i++){
        if($arr1[$i]==-1){
           $arr1[$i]=$_POST['send'];
           print( $_SESSION['znach']) ;
           return;
        }
    }
    $_SESSION['znach']=$arr1;
  }
  require_once("index9.php");
?>