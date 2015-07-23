#include <stdio.h>
#include <stdlib.h>
#include <math.h>

int convertInHour(int x);//converte segundos em horas;

int main(){
	int S; //S = second;
	scanf("%d", &S);
	
	convertInHour(S);
	return 0;
}
convertInHour(int x){
	long double h, m;
	int d, minutes, seconds, hour;
	m = x/60.0000000000000000000;
	d = (int)m;
	printf("m = %.19Lg d = %d ", m, d);
	seconds = round(m - d)*60.000000000000000000;
	printf("seconds = %d", seconds);
	
	h = m/60.0000000000000000000;
	d = (int)h;
	printf("h = %.19Lg d = %d ", h, d);
	
	minutes = (h - d)*60.0000000000000000000;
	printf("minutes = %d\n", minutes);

	printf("hour = %d ", hour);
	hour = d;
	printf("%d:%d:%d\n", hour, minutes, seconds);
	
	return 0;
}
