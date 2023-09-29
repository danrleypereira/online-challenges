function computeClosestToZero(ts: number[]): number {
    // Write your code here
    // To debug: console.error('Debug messages...');
    if(ts.length === 0) return 0;
    return ts.reduce((closest, current) => {
        if(Math.abs(current) < Math.abs(closest))
            return current;
        else if(Math.abs(current) == Math.abs(closest))
            return current < closest ? closest : current;
        return closest;
    }, ts[0]);
}

/* Ignore and do not change the code below */
const n: number = parseInt(readline());
const ts: number[] = readline().split(' ').map(j => parseInt(j)).slice(0, n);
const oldWrite = process.stdout.write;
process.stdout.write = chunk => { console.error(chunk); return true }
const solution: number = computeClosestToZero(ts);
process.stdout.write = oldWrite;
console.log(solution);
/* Ignore and do not change the code above */
