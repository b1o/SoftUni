function main(arr) {
    let array = [];
    for (let i = 0; i < arr.length; i++) {
        let tokens = arr[i].split(" ");
        if (tokens[0] == "add") {
            let number = Number(tokens[1]);
            array.push(number);
        } else {
            let index = Number(tokens[1]);
            array.splice(index, 1);
        }
    }

    for (let i of array) {
        console.log(i);
    }
}

main(['add 3', 'add 5', 'add 7']);