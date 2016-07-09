<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Odd Numbers from N to 1</title>
</head>
<body>
<form>
    Count: <input type="number" name="num" />
    <input type="submit" />
</form>

<?php
if (isset($_GET['num'])) {
    $count = intval($_GET['num']);

    for ($i = $count; $i > 0; $i--) {
        if ($i % 2 != 0) {
            echo $i . " ";
        }
    }
}
?>
</body>
</html>