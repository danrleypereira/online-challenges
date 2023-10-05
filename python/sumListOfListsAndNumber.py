def FX(lst: list) -> int:
    total = 0
    for element in lst:
        if not isinstance(element, list):
            total += element 
        else:
            total += FX(element)

    return total

FX([1,2,3,[1,2,[1]]])
