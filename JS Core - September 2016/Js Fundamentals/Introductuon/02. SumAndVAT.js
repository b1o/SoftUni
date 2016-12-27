function main(arr) {
    let sum = 0;
    let vat = 0;
    let total = 0;

    for (let number in arr) {
        sum += Number(arr[number]);
    }
    vat = sum * 0.2;
    total = sum + vat;

    console.log(`sum = ${sum}`);
    console.log(`VAT = ${vat}`);
    console.log(`total = ${total}`);
}

main(['1.20', '2.60', '3.50']);