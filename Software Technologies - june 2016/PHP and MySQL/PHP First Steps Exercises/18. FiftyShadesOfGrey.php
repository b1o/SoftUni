<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>
    <style>
        div {
            display: inline-block;
            margin: 5px;
            width: 20px;
            height: 20px;
        }
    </style>
</head>
<body>
    <?php
        $colorIndex = 51;
        for ($row = 0; $row < 5; $row++) {
            for ($col = 0; $col < 10; $col++) {
                $color = ($colorIndex*$row) + (5*$col);
                printf('<div style="background-color: rgb(%d, %d, %d);"></div>', $color, $color, $color);
            }
            echo '<br>';
        }
    ?>
</body>
</html>