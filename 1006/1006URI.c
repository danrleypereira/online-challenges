#include <stdio.h>
#include <stdlib.h>
 
int main(){
        double A, B, C, MEDIA;
        do{
                 
                scanf("%lf", &A);
                scanf("%lf", &B);
                scanf("%lf", &C);
                 
        }while(A>10 || B>10 || C>10);
 
        MEDIA = ((A*2)+(B*3)+(C*5))/10;
        printf("MEDIA = %.1lf\n", MEDIA);
 
        return 0;
}
