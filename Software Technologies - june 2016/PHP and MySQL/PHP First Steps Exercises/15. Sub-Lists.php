<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Sub-Lists</title>
</head>
<body>
    <form>
        Number of lists: <input type="number" name="num1" />
        Number of sub-lists: <input type="number" name="num2" />
        <input type="submit" />
    </form>

    <ul>
        <?php
        if (isset($_GET['num1']) && isset($_GET['num2'])) {
            $listsCount = intval($_GET['num1']);
            $subListsCount = intval($_GET['num2']);

            for ($listNumber = 1; $listNumber <= $listsCount; $listNumber++) {
                ?>
                <li>List <?= $listNumber ?>
                    <ul>
                        <?php
                            for ($subListElement = 1; $subListElement <= $subListsCount; $subListElement++) {
                        ?>

                                <li>Element <?= $listNumber ?>.<?= $subListElement ?></li>

                        <?php
                            }
                        ?>
                    </ul>
                </li>
        <?php
            }
        }
        ?>
    </ul>
</body>
</html>