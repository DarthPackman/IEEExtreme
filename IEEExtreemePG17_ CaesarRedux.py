"""Caesar Redux
Time limit: 2500 ms
Memory limit: 256 MB

The Caesar cipher is a simple encryption technique that was used by Julius Caesar to send secret messages to his allies. It works by shifting the letters in the plaintext message by a certain number of positions. Decryption is performed by shifting in the opposite direction by the same number of positions.

A program that implements this technique is needed to encrypt a plaintext message or decrypt a ciphertext messages. Spaces are not affected by encryption or decryption.

You need to determine whether the value that is provided is plaintext or ciphertext. If the value provided is plaintext, you should output the encrypted message given the shift value above. If the provided value is ciphertext, you should output the decrypted message.

Standard Input
Input begins with an integer 
?
n on a line by itself that indicates how many messages are in the input.

The next 
2
?
2n lines contain a line with the shift amount followed by a line with either a plaintext or a ciphertext message.

Standard Output
For each message in the input, output the plaintext if the message is ciphertext, or the ciphertext if the message is plaintext.

Constraints and notes
1
?
?
?
25
1?n?25
The shift value will be between 1 and 25, inclusive.
Each message will consist of lowercase letters and spaces, and contain between 3 and 300 characters.
If the message provided contains the word "the", then it is plaintext. Otherwise, it is ciphertext.
"""
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