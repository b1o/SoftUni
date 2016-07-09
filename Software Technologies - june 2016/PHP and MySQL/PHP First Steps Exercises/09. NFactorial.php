<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>N Factorial</title>
</head>
<body>
    <form>
        N: <input type="number" name="num" />
        <input type="submit" />
    </form>

    <?php
        if (isset($_GET['num'])) {
            $count = intval($_GET['num']);
            $factorial = 1;
            for ($i = 2; $i <= $count; $i++) {
                $factorial *= $i;
            }
        }

        echo $factorial;
    ?>
</body>
</html>