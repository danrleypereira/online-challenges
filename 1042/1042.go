package main

import (
	"fmt"
	"log"
	"sort"
)

func sorted(i, j, k int) (int, int, int)	{
	ints := []int{i, j, k}
	sort.Ints(ints)
	return ints[0], ints[1], ints[2]
}

func main() {
	var a, b, c int
 		
	if    _, err := fmt.Scan(&a, &b, &c);    err != nil {
		log.Print("  Scan for i, j & k failed, due to ", err)
		return
	}
	i, j, k := sorted(a, b, c)
	fmt.Printf("%d\n%d\n%d\n\n", i, j, k)
	fmt.Printf("%d\n%d\n%d\n", a, b, c)
//end of main
}
