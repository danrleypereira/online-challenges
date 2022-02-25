#include <stdio.h>
#include <stdlib.h>

int main(){
	int number, hourWorked;
	double salaryHour, salary;
	scanf("%d", &number);
	scanf("%d", &hourWorked);
	scanf("%lf", &salaryHour);	
	
	salary = hourWorked * salaryHour;
	printf("NUMBER = %d\n", number);
	printf("SALARY = U$ %.2lf\n", salary );
	
	return 0;
}
