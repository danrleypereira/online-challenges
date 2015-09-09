#include <stdio.h>
#include <stdlib.h>

int valueInsert, counter(int y);
int notas[7] = {100, 50, 20, 10, 5, 2, 1};

int main(){
	int i;

	do{
		scanf("%d", &valueInsert);
	}while(valueInsert > 1000000 || valueInsert < 0);
	
	for(i = 0; i < 7; i++){
		printf("%d nota(s) de R$ %d,00 \n", counter(notas[i]), notas[i]);
	}
	
	return 0;
}

int counter(int valueNota){
	int value = valueInsert/valueNota;	
	valueInsert = valueInsert % valueNota;

	return value;
}
