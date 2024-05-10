def pythagorean_triplet_by_sum(sum: int) -> None:
    for a in range(0, sum + 1):
        for b in range(0, sum + 1):
            for c in range(0, sum + 1):
                if (a + b + c) == sum and (a ** 2 + b ** 2) == (c ** 2) and a < b < c:
                    print(f"{a} < {b} < {c}")


if __name__ == '__main__':
    pythagorean_triplet_by_sum(234)
