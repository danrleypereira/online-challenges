// you can write to stdout for debugging purposes, e.g.
// console.log('this is a debug message');

function solution(N) {
    //constant reference to an array
    const A = []
    for(i=0; i<N; i++)
        //random decimal multiplied by 100 and round result
        A.push( Math.floor(Math.random() * 100) )
    return A
}
