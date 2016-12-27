function main(arr) {
    let matrix = [];
    let bombs = [];
    let snowballDamageDone = 0;
    let snowballKillCount = 0;

    for(let i = 0; i < arr.length - 1; i++) {
        let tempArr = arr[i].split(' ').map(x => Number(x));
        matrix.push(tempArr);
    }

    if (arr[arr.length - 1].indexOf(',') > -1) {
        let bombTokens = arr[arr.length - 1].split(' ');
        for (let i = 0; i < bombTokens.length; i++) {
            let bombCoords = bombTokens[i].split(',');
            let bomb = {};
            bomb.x = Number(bombCoords[0]);
            bomb.y = Number(bombCoords[1]);
            bombs.push(bomb);
        }
    }

    if (bombs.length > 0) {
        for (let bomb of bombs) {
            let bombDamage = matrix[bomb.x][bomb.y];
            if (bombDamage > 0) {
                snowballDamageDone += bombDamage;
                snowballKillCount++;
                for (let i = -1; i <= 1; i ++) {
                    for (let j = -1; j <= 1; j++) {
                        if (bomb.x + i >= 0 && bomb.x + i < matrix[0].length && bomb.y + j >= 0 && bomb.y + j < matrix.length )
                            if (matrix[bomb.x + i][bomb.y + j] > 0)
                                matrix[bomb.x + i][bomb.y + j] -= bombDamage;
                    }
                }
            }
        }
    }

    for (let i = 0; i < matrix.length; i ++) {
        for (let j = 0; j < matrix[0].length; j++) {
            if (matrix[i][j] > 0) {
                snowballDamageDone += matrix[i][j];
                snowballKillCount++;
            }
        }
    }

    console.log(snowballDamageDone);
    console.log(snowballKillCount);
}

let arr = [
    "1 10 10 10",
    "10 10 10 10",
    "10 10 10 10",
    "10 10 10 10"
];

main(arr);
