#include <stdio.h>
#include <stdlib.h>

int main(){
        char name;
        double salaryFixed, sales, salaryTotal;
        scanf("%10s", &name);
        scanf("%lf", &salaryFixed);
        scanf("%lf", &sales);

        salaryTotal = salaryFixed + sales * 0.15;
        printf("TOTAL = R$ %.2lf\n", salaryTotal );

        return 0;
}

