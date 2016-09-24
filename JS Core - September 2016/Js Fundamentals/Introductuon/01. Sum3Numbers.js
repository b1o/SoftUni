function main(arr) {
    let sum = 0;
    for (let number in arr) {
        sum += Number(arr[number]);
    }

    console.log(sum);
}

main(['2', '3', '4']);