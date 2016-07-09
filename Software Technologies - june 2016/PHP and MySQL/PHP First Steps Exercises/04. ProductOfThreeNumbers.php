<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Product of 3 Numbers</title>
</head>
<body>
    <form>
        X: <input type="text" name="num1" />
        Y: <input type="text" name="num2" />
        Z: <input type="text" name="num3" />
        <input type="submit" />
    </form>
    <?php
        if (isset($_GET['num1']) && isset($_GET['num2']) && isset($_GET['num3'])) {
            $num1 = intval($_GET['num1']);
            $num2 = intval($_GET['num2']);
            $num3 = intval($_GET['num3']);
            $nums = [$num1, $num2, $num3];

            $negativeCount = 0;
            $specialCase = false;

            foreach ($nums as $num) {
                if ($num == 0) {
                    $specialCase = true;
                }

                if ($num < 0) {
                    $negativeCount++;
                }
            }

            if ($negativeCount % 2 == 0) {
                echo 'Positive';
            } elseif ($specialCase) {
                echo 'Positive';
            } else {
                echo 'Negative';
            }
        }
    ?>
</body>
</html>