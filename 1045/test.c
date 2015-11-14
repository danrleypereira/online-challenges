#include <stdio.h>
#include <stdlib.h>

double EhTriangulo(double a, double b, double c);
void TipoTriangulo(double a, double b, double c);
double main()
{
	double a, b, c;
	scanf("%lf", &a);
	scanf("%lf", &b);
	scanf("%lf", &c);
	if(EhTriangulo(a, b, c))
	{
		TipoTriangulo(a, b, c);
	}
	
	return 0;
}

double EhTriangulo(double a, double b, double c)
{
	double ab = a < b ? -1 : 1;
	double ac = a < c ? -1 : 1;
	double bc = b < c ? -1 : 1;
	if(((bc*(b-c))<a && a<(b+c)) && ((ac*(a-c))<b && b<(a+c)) && ((ab*(a-b))<c && c<(a+b)))
	{
		return 1;
	}else
	{
		printf("NAO FORMA TRIANGULO\n");
		return 0;
	}
}

static double compare (const void *a, const void *b)
{
      const double *ia = (const double *)a; // casting podoubleer types 
          const double *ib = (const double *)b;
              return *ia  - *ib; 
}

void ordenar_valores(double* a, double* b, double* c)
{
	double array[3] = {*a, *b, *c};
	int i;
	printf("antes do qsort\n");
	for(i=0; i<3; i++)
	{
		printf("%lf ", array[i]);
	}
	qsort(array, sizeof(array)/sizeof(array[0]), sizeof(array[0]), compare);
	printf("\ndepois do qsort\n");
	for(i=0; i<3; i++)
	{
		printf("%lf ", array[i]);
	}
	printf("\n");
	*a = array[2];
	*b = array[1];
	*c = array[0];
}

void TipoTriangulo(double a, double b, double c)
{
	ordenar_valores(&a, &b, &c);
	printf("\na= %lf b= %lf c= %lf\n", a, b, c);
	if( (a*a) < ((b*b)+(c*c)) )
	{
		printf("TRIANGULO ACUTANGULO\n");
	}
	if( (a*a) > ((b*b)+(c*c)) )
	{
		printf("TRIANGULO OBTUSANGULO\n");
	}
	if( (a*a) == ((b*b)+(c*c)) )
	{
		printf("TRIANGULO RETANGULO\n");
	}
	if((a==b) && (a==c) && (b==c))
	{
		printf("TRIANGULO EQUILATERO\n");
	}
	if( ((a==b) && (b!=c)) || ((a==c) && (a!=b)) || ((b==c) && (b!=a)) )
	{
		printf("TRIANGULO ISOSCELES\n");
	}
}
