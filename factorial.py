from array import array

def another_factorial(n):
    if n==0 or n==1:
        return 1
    return n*another_factorial(n-1)

def loop_factorial(n):
    ans = 1
    for i in range(1, n+1): #n+1 (exclusive)
        ans *= i
    return ans

def factorial(n) -> int:
    return 1 if n==0 or n==1 else n*factorial(n-1)

def calculate_factorials_of(arr: array) -> None:

    if not arr or arr[0] <= 0:
        print("Invalid input: The first element must be a positive integer representing the count of numbers to follow.")
        return
    
    count = arr[0]
    if len(arr) - 1 != count:
        print(f"Invalid input: Expected {count} numbers to follow, but got {len(arr) - 1}.")
        return

    for number in arr[1:]:  # Skip the first element, which is the count
        if not isinstance(number, int) or number < 0:
            print(f"Invalid input: {number} is not a non-negative integer.")
            continue
        print(f"The factorial of {number} is {factorial(number)}")
        print(f"The factorial of {number} is {another_factorial(number)}")
        print(f"The factorial of {number} is {loop_factorial(number)}")

numbers = array('I', [6, 0, 1, 6, 3, 5, 10])
calculate_factorials_of(numbers)