from numpy.core.defchararray import strip

def parser():
    while True:
        data = input()  # Read the entire line as input
        if data:
            yield data

def get_line():
    return next(input_parser)

def get_number():
    data = get_line()
    try:
        return int(data)
    except ValueError:
        return float(data)

def shift_text(shift, data):
    result = ''
    for char in data:
        if char.isalpha():
            x = ord(char)
            x = (x - ord('a') + shift) % 26
            result += chr(x + ord('a'))
        else:
            result += char
    result = strip(result)
    return result

def check_status(shift, data):
    words = data.split()  
    found_the = False

    for word in words:
        if word == "the":
            found_the = True
            break 

    if found_the:
        return shift_text(-shift, data)
    else:
        return shift_text(shift, data)

input_parser = parser()

count = get_number()
for _ in range(count):
    shift = get_number()
    data = get_line()  
    result = check_status(shift, data)
    print(result)