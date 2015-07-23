#include<stdio.h>
#include<stdlib.h>
#define PI 3.14159
int main(){
	double area, R;
	
	scanf("%lf", &R);
	area = (R*R) * PI;
	printf("A=%.4lf\n", area);	
	return 0;
}

