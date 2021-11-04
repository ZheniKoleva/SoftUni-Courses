package L04ForLoop.lab;

import java.util.Scanner;

public class P08NumberSequence {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int numbersCount = Integer.parseInt(scanner.nextLine());

        int maxNumber = Integer.MIN_VALUE;
        int minNumber = Integer.MAX_VALUE;

        for (int i = 0; i < numbersCount; i++) {
            int currentNumber = Integer.parseInt(scanner.nextLine());

            if (currentNumber > maxNumber) {
                maxNumber = currentNumber;
            }

            if (currentNumber < minNumber) {
                minNumber = currentNumber;
            }
        }

        System.out.printf("Max number: %d%n" + "Min number: %d",
                maxNumber, minNumber);
    }
}
