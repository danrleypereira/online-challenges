#include <stdio.h>
#include <stdlib.h>

int EhTriangulo(double A, double B, double C);
void TipoTriangulo(double A, double B, double C);
void ordenar_valores(double* A, double* B, double *C);
int main()
{
	double A, B, C;
    do{
	    scanf("%lf", &A);
    }while(A<0);
    do{
	    scanf("%lf", &B);
    }while(B<0);
    do{
	    scanf("%lf", &C);
    }while(C<0);
    ordenar_valores(&A, &B, &C);
	if(EhTriangulo(A, B, C))
	{
		TipoTriangulo(A, B, C);
	}
	
	return 0;
}

int EhTriangulo(double A, double B, double C)
{
	int AB = A < B ? -1 : 1;
	int AC = A < C ? -1 : 1;
	int BC = B < C ? -1 : 1;
	if(((BC*(B-C))<A && A<(B+C)) && ((AC*(A-C))<B && B<(A+C)) && ((AB*(A-B))<C && C<(A+B)))
	{
		return 1;
	}else
	{
		printf("NAO FORMA TRIANGULO\n");
		return 0;
	}
}

int compare (const void *A, const void *B)
{
      const double *iA = (const double *)A; // casting pointer types 
          const double *iB = (const double *)B;
              return *iA  - *iB; 
}

void ordenar_valores(double* A, double* B, double* C)
{
	double array[3] = {*A, *B, *C};
	int i;
	qsort(array, 3, sizeof(double), compare);
	printf("\n");
	*A = array[2];
	*B = array[1];
	*C = array[0];
}

void TipoTriangulo(double A, double B, double C)
{
	if( (A*A) == ((B*B)+(C*C)) )
	{
		printf("TRIANGULO RETANGULO\n");
	}
	if( (A*A) > ((B*B)+(C*C)) )
	{
		printf("TRIANGULO OBTUSANGULO\n");
	}
	if( (A*A) < ((B*B)+(C*C)) )
	{
		printf("TRIANGULO ACUTANGULO\n");
	}
	if((A==B) && (A==C) && (B==C))
	{
		printf("TRIANGULO EQUILATERO\n");
	}
	if( ((A==B) && (B!=C)) || ((A==C) && (A!=B)) || ((B==C) && (B!=A)) )
	{
		printf("TRIANGULO ISOSCELES\n");
	}
}
