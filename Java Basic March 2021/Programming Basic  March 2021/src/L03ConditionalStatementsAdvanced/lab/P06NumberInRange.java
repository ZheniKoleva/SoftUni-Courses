package L03ConditionalStatementsAdvanced.lab;

import java.util.Scanner;

public class P06NumberInRange {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int number = Integer.parseInt(scanner.nextLine());
        boolean isValid = (number >= -100 && number <= 100) && number != 0;
        String output = isValid ? "Yes" : "No";
        System.out.println(output);
    }
}
