function main(arr) {
    let obj = {};

    for (let data of arr) {
        let tokens = data.split(" -> ");
        let key = tokens[0];
        obj[key] = Number(tokens[1]) || tokens[1];
    }

    console.log(JSON.stringify(obj));
}

main(["name -> pedal", "age -> 24"]);