A = [23, 92, 27, 0]
B = [4, 2, 4, 5]

function find_min(A) {
    var ans = 0;
    for (var i = 1; i < A.length; i++) {
        if (ans > A[i]) {
            ans = A[i];
        }
    }
    return ans;
}

console.log( find_min(A) )
console.log( find_min(B) )