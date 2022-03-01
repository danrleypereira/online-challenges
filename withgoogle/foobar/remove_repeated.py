# array = [44, 1, 2, 1, 3, 4, 7, 8, 12, 1, 8, 2, 2, 12, 12, 8, 33, 45, 44, 45, 33]
# array = [1, 2, 2, 3, 3, 3, 4, 5, 5]
array = [1, 2, 2, 3, 3, 3, 4, 5, 5]
n= 1
print (array)
def solution(array, n):
    i = 0
    while (i < len(array)):
        if array.count(array[i]) > n:
            numberToDelete = array[i]
            array = [value for value in array if value != numberToDelete]
            # filter(lambda a: a != numberToDelete, array)
            i = 0
            continue
        i += 1
    return array
                
print (solution(array, n))
