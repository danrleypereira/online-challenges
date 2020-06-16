package diamondfinder;

import java.util.ArrayList;
import java.util.Scanner;
import diamondfinder.Stack;

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
	
	private static int howManyDiamonds(Stack stack) {
		int howMany = 0;
		char ch;
		
		while( stack.hasItem() && stack.hasDifferenteCharacteres() ) {
			ch = stack.pop();
			howMany+=isMatch(ch, stack);
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
			case '<': 
				if(nextCh == '>')
					//if match return 1
					return 1;
				break;
			case '>':
				if(nextCh == '<')
					//if match return 1
					return 1;
		}
		//if don't match check if has another character at stack
		if( stack.hasItem() ) {
			//ask if match with the next one
			if( isMatch(ch, stack) == 1 ) {
				stack.push(nextCh);
				return 1;
			}
		}
		
		//If can't match push top stack item back
		stack.push(nextCh);
		return 0;
	}
	
	private static void setStack(String string, Stack stack) {
		char[] ch = string.toCharArray();
		for(int i = 0; i < ch.length; i++) {
			if('>' == ch[i] || '<' == ch[i])
				stack.push( ch[i] );
		}
	}

}
