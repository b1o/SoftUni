<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Draw an S with buttons</title>
</head>
<body>
    <?php
        for ($row = 0; $row < 9; $row++) {
            for ($col = 0; $col < 5; $col++) {
                if ($row == 0 || $row == 4 || $row == 8) {
                    echo '<button style="background-color:blue;">1</button>';
                } elseif ($row > 0 && $row < 4 && $col == 0) {
                    echo '<button style="background-color:blue;">1</button>';
                } elseif ($row > 4 && $row < 9 && $col == 4) {
                    echo '<button style="background-color:blue;">1</button>';
                } else {
                    echo '<button>0</button>';
                }
            }
            echo '<br>';
        }
    ?>
</body>
</html>