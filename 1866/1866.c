#include <stdio.h>
#define true 1
#define false 0

void check_number(int *number);
int isPar();

int main()
{
  int C, i, S =0;
  
  check_number(&C);

  for(i=1; i<=C; i++)
  {
    if( isPar(i) )
    {
      S -= 1;
    }else
    {
      S += 1;
    }
  }
  printf("%d", S);

  return 0;
}

void check_number(int *number)
{
  do{
    scanf("%d", number);
  }while( (number<=1000) && (number>=1) );
}

int isPar(int number)
{
  if(((number/(double)2) - (number/2)) == 0.00)
  {
    return true;
  }else
  {
    return false;
  } 
}
