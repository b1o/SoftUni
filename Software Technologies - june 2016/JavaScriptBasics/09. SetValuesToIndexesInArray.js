function set(arr) {
    let n = Number(arr[0]);
    let result = [n];

    for (let i = 1; i < arr.length; i++) {
        let tokens = arr[i].split(" - ");
        result[Number(tokens[0])] = Number(tokens[1]);
    }

    for (let i = 0; i < n; i++) {
        if (result[i]) {
            console.log(result[i]);
        } else {
            console.log(0)
        }
    }
}

let arr = [
    "2",
    "0 - 5",
    "0 - 6",
    "0 - 7"];

set(arr);