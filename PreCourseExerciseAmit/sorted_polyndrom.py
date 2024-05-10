def is_palindrome(is_palindrome_string: str) -> bool:
    for i in range(len(is_palindrome_string) // 2):
        if is_palindrome_string[i] != is_palindrome_string[len(is_palindrome_string) - i - 1]:
            return False
    return True


def is_sorted_string(is_sorted_palindrome_word: str) -> bool:
    if len(word) % 2 == 0:
        half_string_len = (len(is_sorted_palindrome_word) // 2 - 1)
    else:
        half_string_len = len(is_sorted_palindrome_word) // 2
    for i in range(half_string_len):
        if word[i] > word[i + 1]:
            return False
    return True


def is_sorted_palindrome(is_sorted_palindrome_word: str) -> bool:
    if not is_sorted_palindrome_word.isalpha() and not is_sorted_palindrome_word.isdigit():
        return False
    if not is_palindrome(is_sorted_palindrome_word):
        return False
    return is_sorted_string(is_sorted_palindrome_word)


if __name__ == '__main__':
    word = "abcdfdcba"
    print(is_sorted_palindrome(word))