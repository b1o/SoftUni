function main(arr) {
    let result = {};

    for (let i = 0; i < arr.length - 1; i++) {
        let tokens = arr[i].split(' ');
        let key = tokens[0];
        let value = tokens[1];

        if (result[key]) {
            result[key].push(value);
        } else {
            result[key] = [value];
        }
    }
    let searchedKey = arr[arr.length - 1];
    if (result[searchedKey] && result[searchedKey].length != 0) {
        for (let i of result[searchedKey]) {
            console.log(i)
        }
    } else {
        console.log("None")
    }
}

main(["key value", "key eualv", "test tset", "key"]);