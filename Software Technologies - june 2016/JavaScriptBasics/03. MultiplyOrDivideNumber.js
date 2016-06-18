function main(arr) {
    let n = Number(arr[0]);
    let x = Number(arr[1]);

    if (x >= n) {
        return n * x;
    } else if (n > x) {
        return n / x;
    }
}