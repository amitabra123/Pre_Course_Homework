import matplotlib.pyplot as mp
import numpy as np
from math import sqrt

if __name__ == '__main__':
    num = input("number:")
    num = float(num)
    numbers_list = []
    while num != -1.0:
        numbers_list.append(num)
        num = input("number:")
        num = float(num)
    count_user_input_numbers = 0
    sum_user_input_numbers = 0.0
    count_positive_user_input_numbers = 0
    for number in numbers_list:
        count_user_input_numbers += 1
        sum_user_input_numbers += number
        if number > 0:
            count_positive_user_input_numbers += 1
    avg_input = sum_user_input_numbers / count_user_input_numbers
    print(f"the average is: {avg_input}")
    print(f"the number of positive numbers is: {count_positive_user_input_numbers}")
    print(f"the sorted list: \n {sorted(numbers_list)}")

    amount_of_input_numbers = []
    sum_of_input_numbers_amount = 0
    for i in range(len(numbers_list)):
        amount_of_input_numbers.append(i + 1)
        sum_of_input_numbers_amount += i + 1

    avg_input_numbers_amount = sum_of_input_numbers_amount / len(amount_of_input_numbers)
    sum_x_minus_avg = 0.0
    sum_y_minus_avg = 0.0
    sum_x_minus_avg_times_y_minus_avg = 0.0
    for i in amount_of_input_numbers:
        sum_x_minus_avg += (i - avg_input_numbers_amount) ** 2
    for i in range(len(numbers_list)):
        sum_y_minus_avg += (numbers_list[i] - avg_input) ** 2
    for i in amount_of_input_numbers:
        sum_x_minus_avg_times_y_minus_avg += (
            ((i - avg_input_numbers_amount) * (numbers_list[i - 1] - avg_input)))
    pearson_correlation = sum_x_minus_avg_times_y_minus_avg / (sqrt(sum_x_minus_avg * sum_y_minus_avg))

    x_points = np.array(amount_of_input_numbers)
    y_points = np.array(numbers_list)

    mp.plot(x_points, y_points, 'o')
    mp.title(f"the pearson correlation coefficient is:{pearson_correlation}")
    mp.show()