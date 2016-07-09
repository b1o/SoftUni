<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Multiply a Number by 2</title>
</head>
<body>
    <form>
        N: <input type="number" name="num" />
        <input type="submit" />
    </form>
    <?php
        if (isset($_GET['num'])) {
            $num = $_GET['num'];
            echo $num * 2;
        }
    ?>
</body>
</html>