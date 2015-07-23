#include <stdio.h>
#include <stdlib.h>

int counter(int y);
double HT;
int main(){
	do{
		scanf("%lf", &HT);
	}while(HT > 1000000 || HT < 0);
	
	printf("%.0lf\n", HT);
	
	counter(100);
	printf("HT = %.4lf\n", HT);
	counter(50);
	printf("HT = %.4lf\n", HT);
	counter(20);
	printf("HT = %.4lf\n", HT);
	counter(10);
	printf("HT = %.4lf\n", HT);
	counter(5);
	printf("HT = %.4lf\n", HT);
	counter(2);
	printf("HT = %.4lf\n", HT);
	counter(1);
	printf("HT = %.4lf\n", HT);
	
	return 0;	
}
counter(int y){
	double numberLF, decpart;
	int numberInt;
	
	numberLF = HT/y;
	printf("numberLF = %lf", numberLF);
	numberInt = (int)numberLF;
	printf("numberInt = %d", numberInt);
	decpart = numberLF - numberInt;
	printf("decpart = %lf", decpart);
	if(numberLF != numberInt){
		HT = decpart * y;
		printf("%d nota(s) de R$ %d,00\n", numberInt, y);
	}
	else{
		printf("%lf nota(s) de R$ %.2d\n PORRA\n", numberLF, y);
		HT = 0;
	}
	
	return 0;
}
