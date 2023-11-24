import { fizzBuzz } from "../src/fizzBuzz";

describe('FizzBuzz', () => {
    it.each([3, 6, 9])('should return Fizz to multiples of 3', (integer) => {
        expect(fizzBuzz(integer)).toBe("Fizz");
    });
    it.each([5, 10, 20])('should return Buzz to multiples of 5', (integer) => {
        expect(fizzBuzz(integer)).toBe("Buzz");
    });
    it.each([15, 45, 30])('should return FizzBuzz to multiples of 3 and 5', (integer) => {
        expect(fizzBuzz(integer)).toBe("FizzBuzz");
    });

    it.each`
        input | output
        ${1} | ${"1"}
        ${2} | ${"2"}
        ${4} | ${"4"}
        ${7} | ${"7"}
    `('convert number $input to be the string $output', ({input, output}) => {
        expect(fizzBuzz(input)).toBe(output);
    })
});