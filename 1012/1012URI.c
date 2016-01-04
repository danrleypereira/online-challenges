#include <stdio.h>
#include <stdlib.h>
#include <math.h>
#define PI 3.14159

int main(){
	double A, B, C, pol[6]; 
	int i, a;
	i = 0;
	
	char name[6][12] = {"TRIANGULO: ", "CIRCULO: ", "TRAPEZIO: ", "QUADRADO: ", "RETANGULO: "};	
	
	scanf("%lf", &A);
	scanf("%lf", &B);
	scanf("%lf", &C);
	
	pol[i++] = (A*C)/2;
	pol[i++] = PI * pow(C ,2);
	pol[i++] = ((A + B)*C)/2;
	pol[i++] = pow(B, 2);
	pol[i++] = A*B;

	a = i;

	for(i=0; i<a; i++){
	printf("%s%.3lf\n", name[i], pol[i]);
	}
	
	return 0;
}
