function main(arr) {
    let objects = [];

    for (let input of arr) {
        objects.push(JSON.parse(input));
    }

    for (let obj of objects) {
        console.log("Name: " + obj.name);
        console.log("Age: " + obj.age);
        console.log("Date: " + obj.date);
    }
}