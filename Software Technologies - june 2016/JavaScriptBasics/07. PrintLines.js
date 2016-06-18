function print(arr) {
    let input = arr[0];
    let counter = 1;

    while (input != "Stop") {
        console.log(input);

        input = arr[counter];
        counter++;
    }
}