#include <stdio.h>
#include <stdlib.h>

int EhTriangulo(double a, double b, double c);
void calcPerimetroTriangulo(double a, double b, double c);
void calcPerimetroTrapezio(double a, double b, double c);

int main()
{
        double a, b, c;
        scanf("%lf", &a);
        scanf("%lf", &b);
        scanf("%lf", &c);
        if(EhTriangulo(a, b, c))
        {
                calcPerimetroTriangulo(a, b, c);
        }else
	{
		calcPerimetroTrapezio(a, b, c);
	}

        return 0;
}

int EhTriangulo(double a, double b, double c)
{
        int ab = a < b ? -1 : 1;
        int ac = a < c ? -1 : 1;
        int bc = b < c ? -1 : 1;
        if(((bc*(b-c))<a && a<(b+c)) && ((ac*(a-c))<b && b<(a+c)) && ((ab*(a-b))<c && c<(a+b)))
        {
                return 1;
        }else
        {
                //printf("Nao e Triangulo\n");
                return 0;
        }
}
void calcPerimetroTriangulo(double a, double b, double c)
{
	double perimetro = a+b+c;
	printf("Perimetro = %.1lf\n", perimetro);
}
void calcPerimetroTrapezio(double a, double b, double c)
{	
	double perimetro = (a+b)*c/2.0;
	printf("Area = %.1lf\n", perimetro);
}
