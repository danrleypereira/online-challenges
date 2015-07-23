#include <stdio.h>
#include <stdio.h>

int main(){
	double V, hour, Consumo;

        scanf("%lf%lf", &hour, &V);

	Consumo = (V*hour)/12; //Consumo em litros;
        printf("%.3lf\n", Consumo);

        return 0;
}
