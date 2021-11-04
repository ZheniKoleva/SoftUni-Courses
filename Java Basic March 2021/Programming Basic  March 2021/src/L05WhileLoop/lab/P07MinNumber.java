package L05WhileLoop.lab;

import java.util.Scanner;

public class P07MinNumber {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String command = scanner.nextLine();

        int minNumber = Integer.MAX_VALUE;

        while (!command.equals("Stop")) {
            int currentNumber = Integer.parseInt(command);

            if (currentNumber < minNumber) {
                minNumber = currentNumber;
            }
            command = scanner.nextLine();
        }

        System.out.println(minNumber);
    }
}
