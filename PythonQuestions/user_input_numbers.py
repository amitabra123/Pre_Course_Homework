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
    numbers_list = sorted(numbers_list)
    print(f"the average is: {sum_user_input_numbers / count_user_input_numbers}")
    print(f"the number of positive numbers is: {count_positive_user_input_numbers}")
    print(f"the sorted list: \n {numbers_list}")