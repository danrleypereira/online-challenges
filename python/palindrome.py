# string will be lowercases only
def isPalindrome(string) -> bool:
	#reversed = ''.join(char for char in string)
  return string == string[::-1]

isPalindrome("eye")