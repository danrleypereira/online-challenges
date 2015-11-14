#include <stdio.h>
#include <stdlib.h>

int EhTriangulo(int a, int b, int c);
void TipoTriangulo(int a, int b, int c);
int main()
{
	int a, b, c;
	scanf("%d", &a);
	scanf("%d", &b);
	scanf("%d", &c);
	if(EhTriangulo(a, b, c))
	{
		TipoTriangulo(a, b, c);
	}
	
	return 0;
}

int EhTriangulo(int a, int b, int c)
{
	int ab = a < b ? -1 : 1;
	int ac = a < c ? -1 : 1;
	int bc = b < c ? -1 : 1;
	if(((bc*(b-c))<a && a<(b+c)) && ((ac*(a-c))<b && b<(a+c)) && ((ab*(a-b))<c && c<(a+b)))
	{
		return 1;
	}else
	{
		printf("NAO FORMA TRIANGULO\n");
		return 0;
	}
}

int compare (const void *a, const void *b)
{
      const int *ia = (const int *)a; // casting pointer types 
          const int *ib = (const int *)b;
              return *ia  - *ib; 
}

void ordenar_valores(int* a, int* b, int* c)
{
	int array[3] = {*a, *b, *c};
	int i;
	printf("antes do qsort\n");
	for(i=0; i<3; i++)
	{
		printf("%d ", array[i]);
	}
	qsort(array, 3, sizeof(int), compare);
	printf("\ndepois do qsort\n");
	for(i=0; i<3; i++)
	{
		printf("%d ", array[i]);
	}
	printf("\n");
	*a = array[2];
	*b = array[1];
	*c = array[0];
}

void TipoTriangulo(int a, int b, int c)
{
	ordenar_valores(&a, &b, &c);
	printf("\na= %d b= %d c= %d\n", a, b, c);
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
