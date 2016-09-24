<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Prime Numbers from N to 1</title>
</head>
<body>
    <form>
        Count: <input type="number" name="num" />
        <input type="submit" />
    </form>

    <?php
        function isPrime($num)
        {
            if($num == 1)
                return false;

            if($num % 2 == 0) {
                return false;
            }

            for($i = 3; $i <= ceil(sqrt($num)); $i = $i + 2) {
                if($num % $i == 0)
                    return false;
            }

            return true;
        }

        if (isset($_GET['num'])) {
            $count = intval($_GET['num']);

            for ($i = $count; $i > 0; $i--) {
                if (isPrime($i)) {
                    echo $i, ' ';
                }
            }
        }
    ?>
</body>
</html>