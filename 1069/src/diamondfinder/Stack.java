package diamondfinder;

import java.util.ArrayList;

public class Stack {
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
