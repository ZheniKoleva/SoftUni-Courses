package L04ForLoop.moreExercise;

import java.util.Scanner;

public class P08EqualPairs {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int numbersCount = Integer.parseInt(scanner.nextLine());

        int previousSum = 0;
        int maxDifference = 0;

        for (int i = 0; i < numbersCount; i++) {
            int num1 = Integer.parseInt(scanner.nextLine());
            int num2 = Integer.parseInt(scanner.nextLine());

            int currentSum = num1 + num2;

            if (previousSum == 0) {
                previousSum = currentSum;

            } else {
                int difference = Math.abs(previousSum - currentSum);
                if (difference > maxDifference) {
                    maxDifference = difference;
                }
                previousSum = currentSum;
            }
        }

        if (maxDifference == 0) {
            System.out.printf("Yes, value=%d", previousSum);
        } else {
            System.out.printf("No, maxdiff=%d", maxDifference);
        }
    }
}
