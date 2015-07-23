#include <stdio.h>
#include <stdio.h>
#include <math.h>

int main(){
        double V, A1, A2, O1, O2, D;

        scanf("%lf%lf", &A1, &O1);
        scanf("%lf%lf", &A2, &O2);

	V = pow((A2-A1), 2) + pow((O2-O1),2);
	D = sqrt(V);
        printf("%.4lf\n", D);

        return 0;
}
