package L03ConditionalStatementsAdvanced.exercise;

import java.util.Scanner;

public class P06OperationsBetweenNumbers {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int num1 = Integer.parseInt(scanner.nextLine());
        int num2 = Integer.parseInt(scanner.nextLine());
        char operator = scanner.nextLine().charAt(0);

        int result = 0;
        String output = null;
        String evenOrOdd = null;

        switch (operator) {
            case '+':
                result = num1 + num2;
                evenOrOdd = result % 2 == 0 ? "even" : "odd";
                output = String.format("%d %s %d = %d - %s",
                                        num1, operator, num2, result, evenOrOdd);
                break;

            case '-':
                result = num1 - num2;
                evenOrOdd = result % 2 == 0 ? "even" : "odd";
                output = String.format("%d %s %d = %d - %s",
                                        num1, operator, num2, result, evenOrOdd);
                break;

            case '*':
                result = num1 * num2;
                evenOrOdd = result % 2 == 0 ? "even" : "odd";
                output = String.format("%d %s %d = %d - %s",
                                       num1, operator, num2, result, evenOrOdd);
                break;

            case '/':
                if (num2 == 0) {
                    output = String.format("Cannot divide %d by zero", num1);
                }else {
                    double devideResult = 1.0 * num1 / num2;
                    output = String.format("%d %s %d = %.2f",
                                           num1, operator, num2, devideResult);
                }
                break;

            case '%':
                if (num2 == 0) {
                    output = String.format("Cannot divide %d by zero", num1);
                }else {
                    result = num1 % num2;
                    output = String.format("%d %s %d = %d",
                                            num1, operator, num2, result);
                }
                break;
        }
        System.out.println(output);
    }
}
