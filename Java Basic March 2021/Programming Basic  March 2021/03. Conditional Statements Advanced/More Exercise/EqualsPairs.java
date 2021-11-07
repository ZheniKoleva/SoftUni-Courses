package L03ConditionalStatementsAdvanced.moreExercise;

import java.util.Scanner;

public class EqualsPairs {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int n = Integer.parseInt(scanner.nextLine());

        int sum = 0;
        int differenceMax = 0;
        int differenceMin = 0;

        for (int i = 0; i < n; i++)
        {
            int number1 = Integer.parseInt(scanner.nextLine());
            int number2 = Integer.parseInt(scanner.nextLine());
            int currentSum = number1 + number2;

            if (currentSum == sum || i == 0) {
                sum = currentSum;

            } else {
                int difference = Math.abs(sum - currentSum);
                if (difference > differenceMax) {
                    differenceMax = difference;
                }

                if (difference < differenceMin) {
                    differenceMin = difference;
                }
                sum = currentSum;
            }
        }
        if (differenceMax == 0) {
            System.out.printf("Yes, value=%d", sum);
        } else {
            System.out.printf("No, maxdiff=%d", differenceMax);
        }
    }
}
