package diamondfinder;

import java.util.ArrayList;
import java.util.Scanner;

public class Main {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		Scanner scanIn = new Scanner(System.in);
		
		//How many lines from the buffer ?
		int n = scanIn.nextInt();
		scanIn.nextLine();
		//end

		//set string array with the lines
		String[] lines = new String[n];
		for(int i=0; i< n; i++) {
			lines[i] = scanIn.nextLine();
		}

		scanIn.close();
		
		ArrayList<Stack> stack = new ArrayList<Stack>();
		for(int i=0; i< n; i++) {
			stack.add( new Stack() );
			setStack( lines[i], stack.get(i) );
			System.out.println( howManyDiamonds(stack.get(i)) );			
		}
		
	}
	
	
	//wrong approach tried after the recursive way approach, 
	//its worked, but I misunderstand the challenge
//	private static int howManyDiamonds2(Stack stack) {
//		int opened = 0;
//		int closed = 0;
//		
//		while( stack.hasItem() ) {
//			if( stack.pop() == '<')
//				opened++;
//			else
//				closed++;			
//		}
//		
//		if(opened <= closed)
//			return opened;
//		else if(closed < opened)
//			return closed;
//		return 0;
//	}
//	
	private static int howManyDiamonds(Stack stack) {
		int howMany = 0;
		char ch;
		
		while( stack.hasItem() && stack.hasDifferenteCharacteres() 
				&& stack.hasDiamonds() ) {
			ch = stack.pop();
			if(isMatch(ch, stack) == 1)
				howMany++;
				
		}
		
		return howMany;
	}
	
	private static int isMatch(char ch, Stack stack) {
		//if has no item return 0
		if(!stack.hasItem())
			return 0;
		
		
		// get the next character to compare
		char nextCh = stack.pop();
		// find a match
		switch (ch) {
		//popped is inverted (><), so has to test upside down the match >< = <>
			case '>': 
				if(nextCh == '<')
					//if match return 1
					return 1;
//			case '>':
//				isMatch(stack.pop(), stack);
		}
		//if don't match check if has another character at stack
		if( stack.hasItem() ) {
			//ask if match with the next one
			if( isMatch(nextCh, stack) == 1 ) {
				stack.push(ch);
				return 1;
			} else if( stack.hasOnlyOne() ) {
				//if don't match and has only one, it means that has no match at all
				return 0;
			}
		}
		
		//If can't match push two top stack items back
		stack.push(nextCh); 
		stack.push(ch);
		return 0;
	}
	
	//clear the string removing sand particles
	private static void setStack(String string, Stack stack) {
		char[] ch = string.toCharArray();
		for(int i = 0; i < ch.length; i++) {
			if('>' == ch[i] || ch[i] == '<' ) {
				stack.push( ch[i] );
			}
		}
	}

}
