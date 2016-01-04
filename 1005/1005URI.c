#include <stdio.h>
#include <stdlib.h>

int main(){
	double N1, N2, MEDIA;
	
	scanf("%lf", &N1);	
	scanf("%lf", &N2);
	MEDIA = ((N1*3.5) + (N2*7.5)) / 11;	
	printf("MEDIA = %.5lf\n", MEDIA);
	return 0;
}
