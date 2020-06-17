import java.io.IOException;
import java.util.ArrayList;
import java.util.Scanner;

 
/**
 * IMPORTANT: 
 *      O nome da classe deve ser "Main" para que a sua solução execute
 *      Class name must be "Main" for your solution to execute
 *      El nombre de la clase debe ser "Main" para que su solución ejecutar
 */

class Stack {
	ArrayList<Character> stack;
	public Stack() {
		stack = new ArrayList<Character>();		
	}
	
	public void push(char ch) {
		stack.add(ch);
	}
	
	public char pop() {
		char poppedChar = stack.get(this.lenght()-1);
		if((this.lenght()-1) >= 0)
			stack.remove(this.lenght()-1);
		else
			return 'e';
		return poppedChar;
	}
	
	public boolean hasItem() {
		if( stack.isEmpty() )
			return false;
		else 
			return true;
	}
	
	public boolean hasDifferenteCharacteres() {
		if(this.hasItem()) {
			for(int i =0; i < stack.size(); i++) {
				for(int j=(i+1); j< stack.size(); j++) {
					if( stack.get(i) != stack.get(j) ) {
						return true;
					}
				}
			}
		}
		return false;
	}
	
	public boolean hasOnlyOne() {
		if(stack.size() == 1)
			return true;
		return false;
	}
	
	public boolean hasDiamonds() {
		if(this.hasItem()) {
			try {
				for(int i=0; i< stack.size(); i++) {
					if( ( stack.get(i) == '<' ) && ( stack.get(i+1) == '>' ) )
						return true;
				}
			} catch(IndexOutOfBoundsException e) {
				return false;
			}
		}
		return false;
	}
	
	public int lenght() {
		return stack.size();
	}
}


public class Main {
 
    public static void main(String[] args) throws IOException {
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
//		int popControl = 0;
//		Stack stack2 = new Stack();
		
		while( stack.hasItem() && stack.hasDifferenteCharacteres() 
				&& stack.hasDiamonds() ) {
			ch = stack.pop();
//			howMany+=isMatch(ch, stack);
			if(isMatch(ch, stack) == 1)
				howMany++;
//			else {
//				popControl++;
//				stack2.push(ch);
//			}
				
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
			case '>': 
				if(nextCh == '<')
					//if match return 1
					return 1;
				break;
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
				return 0;
			}
		}
		
		//If can't match push two top stack items back
		stack.push(nextCh); 
		stack.push(ch);
		return 0;
	}
	
	private static void setStack(String string, Stack stack) {
		char[] ch = string.toCharArray();
		for(int i = 0; i < ch.length; i++) {
			if('>' == ch[i] || ch[i] == '<' ) {
				stack.push( ch[i] );
			}
		}
	}
	
	
}













