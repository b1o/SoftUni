function main(arr) {
    let naskor = {name: "Naskor", damageDone: 0};
    let viktor = {name: "Vitkor", damageDone: 0};

    let naskorSpecialAttackCounter = 1;
    let viktorSpecialAttackCounter = 1;

    let naskorPreviousAttackDamage = 0;
    let vitorPreviousAttackDamage = 0;

    for (let i = 0; i < arr.length; i++) {
        let tokens = arr[i].split(' ');

        let amount = Number(tokens[0]);
        let side = tokens[1];
        if (side == "dark") {
            if (naskorPreviousAttackDamage == amount) {
                naskorSpecialAttackCounter++;

                if (naskorSpecialAttackCounter == 5) {
                    naskor.damageDone += (amount*60)*4.5;
                } else {
                    naskor.damageDone += amount*60;
                }
            } else {
                naskorSpecialAttackCounter = 1;
                naskor.damageDone += amount*60;
            }
            naskorPreviousAttackDamage = amount;
        } else {
            if (vitorPreviousAttackDamage == amount) {
                viktorSpecialAttackCounter++;

                if (viktorSpecialAttackCounter == 2) {
                    viktor.damageDone += (amount*60)*2.75;
                } else {
                    viktor.damageDone += amount*60;
                }
            } else {
                viktorSpecialAttackCounter = 1;
                viktor.damageDone += amount*60;
            }
            vitorPreviousAttackDamage = amount;
        }
    }

    let winner;
    if (naskor.damageDone > viktor.damageDone) {
        winner = naskor;
    } else {
        winner = viktor;
    }

    console.log(`Winner - ${winner.name}`);
    console.log(`Damage - ${winner.damageDone}`);
}

let arr = ["2 dark medenkas",
"1 white medenkas",
"2 dark medenkas",
"2 dark medenkas",
"15 white medenkas",
"2 dark medenkas",
"2 dark medenkas"];

main(arr);