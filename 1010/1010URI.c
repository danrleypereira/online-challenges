#include <stdio.h>
#include <stdlib.h>

int main(){
        int piece, numberPiece;
        double valuePiece, valueTotal; 
        scanf("%d %d %lf", &piece, &numberPiece, &valuePiece);
	valueTotal = valuePiece * numberPiece;
        scanf("%d %d %lf", &piece, &numberPiece, &valuePiece);
	valueTotal += valuePiece * numberPiece;
        printf("VALOR A PAGAR: R$ %.2lf\n", valueTotal);

        return 0;
}

