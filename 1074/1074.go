package main

import (
	"fmt"
	"log"
)

func isNegative(number int) (string) {
	if number < 0 {
		return "NEGATIVE\n"
	} else if number > 0 {
		return "POSITIVE\n"
	} else {
		return "NULL\n"
	}
}

func evenORodd(number int) (string) {
	if number == 0 {
		return ""
	} else if number%2 == 0 {
		return "EVEN "
	} else {
		return "ODD "
	}
}

func main() {
	var howManyNumbers int
	
	if    _, err := fmt.Scan(&howManyNumbers);    err != nil {
		log.Print("  Scan for howManyNumbers failed, due to ", err)
		return
	}

	var i = 0
	for i < howManyNumbers {
		var currentNumber int
		if    _, err := fmt.Scan(&currentNumber);    err != nil {
			log.Print("Scan for cuurentNumber failed, due to ", err)
			return
		}

		fmt.Printf("%s%s", evenORodd(currentNumber),  isNegative(currentNumber) )
		i = i + 1
	}
//end of main
}
