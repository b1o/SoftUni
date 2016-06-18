function main(arr) {
    let result = {};
    for (let i = 0; i < arr.length - 1; i++) {
        let tokens = arr[i].split(' ');
        let key = tokens[0];
        let value = tokens[1];

        result[key] = value || result[key];

    }

    let searchedKey = arr[arr.length - 1];
    if (result[searchedKey]) {
        console.log(result[searchedKey]);
    } else {
        console.log("None");
    }
}

