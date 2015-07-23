#include <stdio.h>
#include <stdlib.h>
#include <math.h>
#define PI 3.14159
int main(){
        double x, V, R;

        scanf("%lf", &R);
        x = pow(R, 3);
        V = (4.0/3) * PI * x;
        printf ("VOLUME = %.3lf\n", V);

        return 0;
}

