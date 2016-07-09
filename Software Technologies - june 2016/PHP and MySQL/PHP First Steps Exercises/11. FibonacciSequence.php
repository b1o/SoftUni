<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Fibonacci Sequence</title>
</head>
<body>
    <form>
        Count: <input type="number" name="num" />
        <input type="submit" />
    </form>

    <?php
        if (isset($_GET['num'])) {
            $count = intval($_GET['num']);
            $sum = 0;
            $first = 0;
            $second = 1;

            echo $second, ' ';
            for ($i = 0; $i < $count-1; $i++) {
                $sum = $first + $second    ;
                echo $sum, ' ';
                $first = $second;
                $second = $sum;
            }
        }
    ?>
</body>
</html>