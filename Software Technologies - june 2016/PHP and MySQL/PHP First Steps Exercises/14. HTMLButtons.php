<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>HTML Buttons</title>
</head>
<body>
    <form>
        Buttons Count: <input type="number" name="num" />
        <input type="submit" />
    </form>

    <?php
        if (isset($_GET['num'])) {
            $count = intval($_GET['num']);

            for ($i = 1; $i <= $count; $i++) {
    ?>
                <button><?= $i ?></button>
    <?php
            }
        }
    ?>
</body>
</html>