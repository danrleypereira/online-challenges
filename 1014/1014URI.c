#include <stdio.h>
#include <stdio.h>

int main(){
        double km, l, cm;

        scanf("%lf %lf", &km, &l);
	
	cm = km/l;
	printf("%.3lf km/l\n", cm);
	
        return 0;
}
