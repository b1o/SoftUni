function product(arr) {
    let n = arr.filter(x => x < 0).length;
    if (n % 2 == 0) {
        console.log("Positive")
    } else {
        console.log("Negative")
    }
}