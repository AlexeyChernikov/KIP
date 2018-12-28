<?php

header("Content-type: text/xml");
$sqlhost="localhost";
$sqluser="root";
$sqlpass="";
$db="zadanie";
$array1 = [];
header('Content-Type:text/html;charset=utf-8');
$link=mysqli_connect($sqlhost,$sqluser,$sqlpass,$db) or die("MySQL не доступен! ".mysqli_error());
if ($result = mysqli_query($link, "SELECT * FROM SS_Products LIMIT 10"))
{
    $fd = fopen("output.xml", 'w') or die("не удалось создать файл");
    fwrite($fd, "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n<items>");
    while($stringresult = $result->fetch_array())
    {
        fwrite ($fd, "
        <item>
          <ProductID>".$stringresult['productID']."</ProductID>
          <name>".$stringresult['name']."</name>
          <Price>".$stringresult['Price']."</Price>
          <product_code>".$stringresult['product_code']."</product_code>
        </item>
      ");
    }
    fwrite($fd, "</items>");
    fclose($fd);
    mysqli_free_result($result);
  }
  mysqli_close($link);
  $filename = 'output.xml';
  $handle = fopen($filename, "rb");
  $contents = fread($handle, filesize($filename));
  fclose($handle);
  print("Данные выгружены в файл output.xml");
?>