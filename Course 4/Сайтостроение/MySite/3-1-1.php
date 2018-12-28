<?php
$back= @$_COOKIE['backgroundColor'];
$ref= @$_COOKIE['ReferenceColor'];
echo '<body style="background:'.$back. '" margin: 0"><p > <font size="5" color="white" face="Arial">Текст</font></p><br> <a href="" style="color:'.$ref.'" margin: 0">Ссылка</a></body>';
?>