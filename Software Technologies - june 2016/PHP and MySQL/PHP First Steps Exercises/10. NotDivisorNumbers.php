<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Not Divisor Numbers</title>
</head>
<body>
    <form>
        Number: <input type="number" name="num" />
        <input type="submit" />
    </form>

    <?php
        if (isset($_GET['num'])) {
            $number = intval($_GET['num']);

            for($i = $number; $i > 0; $i--)
            {
                if (($number%$i) != 0)
                {
                    echo $i,' ';
                }
            }
        }
    ?>
</body>
</html>