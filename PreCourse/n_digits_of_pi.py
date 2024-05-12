import math


def reverse_n_pi_digits(n: int) -> str:
    return str(math.pi)[n:1:-1] + ".3"


print(reverse_n_pi_digits(6))