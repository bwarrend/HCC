package HashedCodeAttempt;
import java.util.*;


public class HashedCodeAttempt {

    //Set the constant static private key so all our little methods can use it
    final private static String PRIVATE_KEY = "superSECRETsecureCODE123!@#";
    
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        
        //Originally take in a name
        System.out.println("Please Etner name");        
        String name = input.nextLine();
        
        //Generate the code and print it out
        System.out.println(generateCode(name));
        
        System.out.println("\n");
        
        //To check the code's validity, we need to input name and code
        System.out.println("Name as written on cert: ");
        String inName = input.nextLine();
        System.out.println("Code:");
        String inCode = input.nextLine();
        
        //Print true of good code and false if bad code
        System.out.println(checkCode(inName, inCode));        
    }
    
    //Take in a name and use the Private key to return a code
    public static String generateCode(String name){
        //Initialize the return string
        String outCode = "";
        
        //Generate the hash from the private key, divide by two to prevent
        //overflow
        int PKHash = Math.abs(PRIVATE_KEY.hashCode()) / 2;
        
        /* TEST OUTPUT*/
        //System.out.println("pkhash = " + PKHash);
        
        //Generate the hash from the name string, divide by two to prevent
        //overflow
        int nameHash = Math.abs(name.hashCode()) / 2;
        
        /* TEST OUTPUT */
        //System.out.println("nmhash = " + nameHash);
        
        //Add the hash from private key and name string save to newHash
        int newHash = Math.abs(PKHash + nameHash);
        
        /* TEST OUTPUT*/
        //System.out.println("phkash - nmhash = " + newhash);
                
        //Make an integer out of the hash
        String newHashString = Integer.toString(newHash);
        
        
        //Create a new string from the hashcode generated, return it
        //
        char tt = 'Z';
        for(int i = 0; i < newHashString.length(); ++i){

            switch(newHashString.charAt(i)){
                case '0': tt = 'A'; break;
                case '1': tt = 'C'; break;
                case '2': tt = 'E'; break;
                case '3': tt = 'F'; break;
                case '4': tt = 'Q'; break;
                case '5': tt = 'R'; break;
                case '6': tt = 'H'; break;
                case '7': tt = '4'; break;
                case '8': tt = '3'; break;
                case '9': tt = '7'; break;
            }
            
            outCode += tt;
        }
        
        return outCode;
    }

    //Take in a name and code and return true if the combo is valid
    public static boolean checkCode(String name, String inCode){
        int PKHash = Math.abs(PRIVATE_KEY.hashCode()) / 2;
        
        /* TEST OUTPUT */
        //System.out.println("pkhash = " + PKHash);
        
        int inNameHash = Math.abs(name.hashCode()) / 2;
        
        /* TEST OUTPUT */
        //System.out.println("abs(in name) = " + inNameHash);
        
        String codeIntS = "";
        
        //Check convert the inputted code char by char to integers
        char tt = 'Z';
        for(int i = 0; i < inCode.length(); ++i){

            switch(inCode.charAt(i)){
                case 'A': tt = '0'; break;
                case 'C': tt = '1'; break;
                case 'E': tt = '2'; break;
                case 'F': tt = '3'; break;
                case 'Q': tt = '4'; break;
                case 'R': tt = '5'; break;
                case 'H': tt = '6'; break;
                case '4': tt = '7'; break;
                case '3': tt = '8'; break;
                case '7': tt = '9'; break;
            }
            
            codeIntS += tt;
        }
        
        /* TEST OUTPUT */
        //System.out.println("Code as intstring = " + codeIntS);
        
        //Turn the string of ints into an actual int
        int codeInt = Integer.parseInt(codeIntS);
        
        /* TEST OUTPUT */
        //System.out.println("Code as int = " + codeInt);
        
        /* TEST OUTPUT */
        //System.out.println("abs codeint - namehash = " + Math.abs(codeInt - inNameHash));
        // System.out.println("pkhash = " + PKHash);
        
        //Return true if the code is valid
        return Math.abs(codeInt - inNameHash) == PKHash;
    }    
}
