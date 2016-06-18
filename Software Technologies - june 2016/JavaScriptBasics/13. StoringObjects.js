function main(arr) {
    let students = [];

    for (let input of arr) {
        let tokens = input.split(" -> ");
        let name = tokens[0];
        let age = Number(tokens[1]);
        let grade = Number(tokens[2]);

        students.push({name: name, age: age, grade: grade});
    }

    for (let student of students) {
        console.log(`Name: ${student.name}`);
        console.log(`Age: ${student.age}`);
        console.log(`Grade: ${student.grade.toFixed(2)}`);
    }
}

main(["Pesho -> 13 -> 6.00", "Ivan -> 12 -> 5.57", "Toni -> 13 -> 4.90"]);