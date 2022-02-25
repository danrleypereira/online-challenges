# 3. Longest Substring Without Repeating Characters
import pdb
# inputs
STRINGS = [("abcabcbb", 3), ("bbbbb", 1),
           ("pwwkew", 3), ("gtrewgtgrewwgtrew", 5),
           ("pwwkalytwkalwkaytlw", 6), ("au", 2),
           ("dvdf", 3), ("gtgrytji", 6),
           ("bpfbhmipx", 7)]


class Queue:
    def __init__(self):
        self.current_substring = []

    def push(self, char: str):
        return self.current_substring.append(char)

    def pop(self):
        return self.current_substring.pop(0)

    def get_length(self):
        # return 0 if list is empty
        return 0 if not self.current_substring else len(self.current_substring)


class Solution:
    # Runtime: 99 ms, faster than 49.22%
    # Memory Usage: 14.1 MB, less than 78.03%
    def lengthOfLongestSubstring(self, s: str) -> int:
        queue = Queue()
        longest_substring_length = 0
        for char in s:
            # initialization of current substring (queue)
            if queue.get_length() == 0:
                queue.push(char)
                # setting substring to algorithm work
                longest_substring_length = 1
                continue

            # current char exists in queue?
            if char in queue.current_substring:
                # if longest substring is bigger than current substring keep it else update length
                longest_substring_length = longest_substring_length if longest_substring_length > queue.get_length(
                ) else queue.get_length()
                # do until find duplicated character
                while True:
                    # found duplicated?
                    if queue.pop() == char:
                        break
            # put current char in current substring
            queue.push(char)
        # if longest substring is bigger than current substring keep it else update length
        longest_substring_length = longest_substring_length if longest_substring_length > queue.get_length(
        ) else queue.get_length()
        return longest_substring_length

    # Runtime: 64 ms
    def bestSolution(self, s: str) -> int:

        left = 0
        len = 0
        d = {}

        for right, char in enumerate(s):
            if char in d:
                left = max(left, d[char]+1)

            d[char] = right
            len = max(len, right-left+1)

        return(len)


def test_assert():
    solution = Solution()
    for index, tuple in enumerate(STRINGS):
        print(tuple)
        assert solution.lengthOfLongestSubstring(tuple[0]) == tuple[1]
