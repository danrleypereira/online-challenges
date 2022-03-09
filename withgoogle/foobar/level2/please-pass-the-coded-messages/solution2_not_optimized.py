def solution(l):
    x = find_largest_bucket(l)
    return find_max_number(x)


def find_largest_bucket(l):
    ''' Are the digits in the list divisible?'''
    if sum(int(digit) for digit in l) % 3 == 0:
        return l

    ''' Find all smaller buckets recursively '''
    buckets = []
    for digit in l:
        if digit not in {0, 3, 6, 9}:
            tmp = l[:]
            tmp.remove(digit)
            buckets.append(find_largest_bucket(tmp))

    largest_bucket = max(buckets, key=find_max_number)
    return largest_bucket


def find_max_number(l):
    '''Returns maximal number that can be generated from list.'''
    sorted_list = sorted(l)[::-1]
    number = ''.join(str(x) for x in sorted_list)
    return int(number)


print(solution([3, 1, 4, 1]))
print(solution([i for i in range(1000000)]))
