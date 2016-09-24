<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Tribonacci Sequence</title>
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
    $first = 1;
    $second = 1;
    $third = 2;

    echo $first, ' ';
    echo $second, ' ';
    echo $third, ' ';

    for ($i = 0; $i < $count-3; $i++) {
        $sum = $first + $second + $third;
        echo $sum, ' ';
        $first = $second;
        $second = $third;
        $third = $sum;
    }
}
?>
</body>
</html>