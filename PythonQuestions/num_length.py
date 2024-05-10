import math


def num_len(number: int) -> int:
    return int(math.log(number, 10) + 1)


if __name__ == '__main__':
    num = 8783898
    print(num_len(num))