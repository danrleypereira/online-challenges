[1, 3, 6, 4, 1, 2]
[1, 10, 8, 2, 4, 3, 6, 4, 1, 2]

function solution(A) {
    var sortedArray = new Float64Array(A);
    sortedArray = sortedArray.sort().filter(function(item, pos, ary) {
        return !pos || item != ary[pos - 1];
    });;
    console.log(sortedArray);
    var teste = sortedArray.reduce((acumulator, currentNumber, currentIndex, array) => {
        console.log(acumulator)
        if((currentNumber - acumulator) > 1 && acumulator >= 0)
            return (acumulator +1);
        return currentNumber;
    });

    console.log(teste)
    return teste;
}

