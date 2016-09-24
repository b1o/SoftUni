<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Even Numbers from 1 to N</title>
</head>
<body>
    <form>
        Count: <input type="number" name="num" />
        <input type="submit" />
    </form>

    <?php
        if (isset($_GET['num'])) {
            $count = intval($_GET['num']);

            for ($i = 1; $i <= $count; $i++) {
                if ($i % 2 == 0) {
                    echo $i . " ";
                }
            }
        }
    ?>
</body>
</html>