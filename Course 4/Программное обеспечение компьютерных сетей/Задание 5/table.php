<!DOCtype html>

<html>

<head>
    <meta charset="UTF-8">
    <title>Черников задание 5</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <style>
    .table1 tr:nth-child(odd) {
        background-color: lightyellow;
    }

    .table1 tr:nth-child(even) {
        background-color: lightgreen;
    }
    .table1 {
        border: 6px solid black;
        
        margin: auto;
    }

    .table1 tr:nth-child(even):hover {
        background-color: lightblue;
    }

    .table1 tr:nth-child(odd):hover {
        background-color: red;
    }
    .table1 tr:nth-child(1):hover {
        background-color: green;
    }
    
    .table1 tr:nth-child(1) {
        background-color: green;
    }
    .ot{
	    margin-left: 10px;
    }
        [class*="col-"] { background-color: #eee; text-align: center; padding-top: 10px; padding-bottom: 10px; margin-bottom: 10px; font-size: 2rem; }
	</style>

</head>

<body>

    
    <table border="2" class="table1">
        <tr>
            <th>ID товара</th>
            <th>Название категории</th>
            <th>Название категории</th>
            <th>Цена</th>
        </tr>
        <?php
        $sqlhost = "localhost";
        $sqluser = "root";
        $sqlpass = "";
        $db      = "zadanie";
        $link = mysqli_connect($sqlhost, $sqluser, $sqlpass, $db) or $resultString = ("MySQL не доступен! " . mysqli_error());
        if (!$link)
            die("Ошибка при подключении к базе данных");
        if (mysqli_connect_error()) {
            $resultString = "Ошибка при подключении к БД!" . mysqli_connect_error();
            exit();
        } else {
            $resultString = "Подключение к базе состоялось!";
        }
        $query = "SELECT DISTINCT SS_products.productID, SS_products.name as 'Prod', SS_categories.name,SS_products.Price FROM zadanie.SS_products, zadanie.SS_categories , zadanie.SS_category_product WHERE zadanie.SS_category_product.productID=SS_products.productID AND zadanie.SS_category_product.categoryID=SS_categories.categoryID LIMIT 250,300";
        $result = mysqli_query($link, $query) or $voo = true;
        if ($voo) {
            echo ("Произошла ошибка при работе с БД! " . mysqli_error($link));
            exit;
        }
        $t        = false;
        $col      = $result->num_rows;
        $CityCOMP = "";
        for($i=0;$i< $col;$i++){
            $result->data_seek($i);
            $row= $result->fetch_assoc();
            echo "<tr><td>".$row['productID']."</td><td>".$row['Prod']."</td><td>".$row['name']."</td><td>".$row['Price']."</td></tr>";

        }
        
        ?>
    </table>
</body>

</html>