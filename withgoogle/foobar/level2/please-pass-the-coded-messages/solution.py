
def sort_and_reverse(l: list):
    l.sort()
    l.reverse()
    return l

def is3multiple(l: list):
    # if empty get out of the loop
    if len(l) == 0:
        return True
    return sum(l) % 3 == 0

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


def solution(l):
    # aparently l is a set
    data_as_list =  list(l)
    data_as_list = sort_and_reverse(data_as_list)
    while not is3multiple(data_as_list):
        data_as_list.pop()
    if len(data_as_list) != 0:
        return transformListInNumber(data_as_list)
    # if couldn't find a divisible number
    else:
        for number in sort_and_reverse(list(l)):
            if number % 3 == 0:
                return number
    return 0
    



def which_type(data):
    print(type(data))
    print(data)


list_data = [3, 1, 4, 1]
list_data2 = [3, 1, 4, 1, 5, 9]
# list_data3 = [3, 2, 4, 5, 5, 9]

# transformListInNumber(list_data)
# transformListInNumber(list_data2)
print('return', solution([2,5]))
print('return', solution(list_data))
print('return', solution(list_data2))
# print('return', solution(list_data3))