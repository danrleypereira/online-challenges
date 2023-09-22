let smallestSubstringWithAllCharacters = function(string, charactersToBeFound){
    //Is there any possible substring of string that contains all characters? (optimization)
    if(charactersToBeFound.length > string.length) return ""
    //if either string is empty, return an empty string
    if(!charactersToBeFound || 
      !string) return ""
  
    //hash tables
    let requiredChars = {};
    let currentChars = {};
  
    //fill the requiredChars hash table with counts of unique chars to be found
    for(let char of charactersToBeFound)
      requiredChars[char] = (requiredChars[char] || 0) +1;
  
    //sliding window pointers
    let left = 0, right = 0;
  
    //keeps track of how many unique characters from charactersToBeFound
    let formed = 0;
    let requiredCount = Object.keys(requiredChars).length;
  
    //start and end indices of the smallest substring found
    let windowLength = Infinity;
    let result = [0, string.length] //the current string given as parameter
  
    //track the count of each characters in our current window (sliding windows technique)
    // # expading window
    while(right < string.length) {
      let char = string[right];
      currentChars[char] = (currentChars[char] || 0) +1; //lol
  
      //Check if the current character completes the required count
      if(requiredChars[char] && currentChars[char] === requiredChars[char])
        formed++;
  
      //minimal string? sliding to the left trying to shrink the window
      //Have we found all the characters in required amounts?
      while(formed === requiredCount && left <= right){
        if(right - left +1 < windowLength){
          windowLength = right - left +1;
          result = [left, right];
        }
  
        //try to reduce the size of window
        char = string[left];
        currentChars[char]--;
        if(requiredChars[char] && currentChars[char] < requiredChars[char])
          formed--;
  
        left++;
      }
      //Move the right pointer to expand the window
      right++;
    }
    //not found
    return windowLength === Infinity ? "" : string.slice(result[0], result[1] +1);
  }
  
  function MinWindowSubstring(strArr) {
    let [n, k] = strArr;
    return smallestSubstringWithAllCharacters(n, k); 
  }
  
  // keep this function call here 
  console.log(MinWindowSubstring(readline()));