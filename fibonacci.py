# return a list with first x numbers from fibonacci sequence
def calculate_sequence(x):
    sequence = [0, 1]
    for _ in range(x):
        sequence.append(sequence[-2] + sequence[-1])
    return sequence 


print (calculate_sequence(5))