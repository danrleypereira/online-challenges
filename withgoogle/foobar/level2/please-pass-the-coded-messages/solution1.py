# Python3 program to find the largest number
# that can be mode from elements of the
# array and is divisible by 3
  
# Number of digits
MAX_SIZE = 10

# create number to return
def transformListInNumber(l: list):
    my_list = l
    my_list.sort()
    the_number = 0
    for index, number in enumerate(my_list):
        place_value = 1
        for _ in range(index):
            place_value *= 10 
        the_number += ( number * place_value )
    return the_number
  
# function to sort array of digits using
# counts
def sortArrayUsingCounts(arr, n):
  
    # Store count of all elements
    count = [0]*MAX_SIZE
    for i in range(n):
        count[arr[i]] += 1
  
    # Store
    index = 0
    for i in range(MAX_SIZE):
        while count[i] > 0:
            arr[index] = i
            index += 1
            count[i] -= 1
  
  
# Remove elements from arr[] at indexes ind1 and ind2
def removeAndPrintResult(arr, n, ind1, ind2=-1):
    l = []
    for i in range(n-1, -1, -1):
        if i != ind1 and i != ind2:
            # print(arr[i], end="")
            l.append(arr[i])
    return transformListInNumber(l)
  
  
# Returns largest multiple of 3 that can be formed
# using arr[] elements.
def largest3Multiple(arr, n):
  
    # Sum of all array element
    s = sum(arr)
  
    # Sort array element in increasing order
    sortArrayUsingCounts(arr, n)
  
    # Sum is divisible by 3, no need to
    # delete an element
    if s % 3 == 0:
        return removeAndPrintResult(arr, n, -1)
        return True
  
  
  
    # Find reminder
    remainder = s % 3
  
    # If remainder is '1', we have to delete either
    # one element of remainder '1' or two elements
    # of remainder '2'
    if remainder == 1:
        rem_2 = [0]*2
        rem_2[0] = -1; rem_2[1] = -1
  
        # Traverse array elements
        for i in range(n):
  
            # Store first element of remainder '1'
            if arr[i] % 3 == 1:
                return removeAndPrintResult(arr, n, i)
                return True
  
            if arr[i] % 3 == 2:
  
                # If this is first occurrence of remainder 2
                if rem_2[0] == -1:
                    rem_2[0] = i
  
                # If second occurrence
                elif rem_2[1] == -1:
                    rem_2[1] = i
  
        if rem_2[0] != -1 and rem_2[1] != -1:
            return removeAndPrintResult(arr, n, rem_2[0], rem_2[1])
            return True
  
    # If remainder is '2', we have to delete either
    # one element of remainder '2' or two elements
    # of remainder '1'
    elif remainder == 2:
        rem_1 = [0]*2
        rem_1[0] = -1; rem_1[1] = -1
  
        # traverse array elements
        for i in range(n):
  
            # store first element of remainder '2'
            if arr[i] % 3 == 2:
                return removeAndPrintResult(arr, n, i)
                return True
  
            if arr[i] % 3 == 1:
  
                # If this is first occurrence of remainder 1
                if rem_1[0] == -1:
                    rem_1[0] = i
                  
                # If second occurrence
                elif rem_1[1] == -1:
                    rem_1[1] = i
                      
        if rem_1[0] != -1 and rem_1[1] != -1:
            return removeAndPrintResult(arr, n, rem_1[0], rem_1[1])
            return True
  
    # print("Not possible")
    return 0
    return False
  
def solution(l):
    n = len(l)
    return largest3Multiple(l, n)
  
# Driver code
if __name__ == "__main__":
  
    arr = [5, 1, 7, 1, 5, 9]
    arr2 = [3, 1, 4, 1, 5, 9]
    arr3 = [3, 1, 4, 1]
    arr1 = [5, 2]
    print(solution(arr2))