package L06NestedLoops.moreExercise;

import java.util.Scanner;

public class P01UniquePINCodes {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int endDigit1 = Integer.parseInt(scanner.nextLine());
        int endDigit2 = Integer.parseInt(scanner.nextLine());
        int endDigit3 = Integer.parseInt(scanner.nextLine());

        for (int digit1 = 2; digit1 <= endDigit1; digit1 += 2) {
            for (int digit2 = 2; digit2 <= endDigit2; digit2++) {
                for (int digit3 = 2; digit3 <= endDigit3; digit3 += 2) {

                    boolean isValidDigit2 = (digit2 == 2 || digit2 % 2 == 1) && digit2 != 9;
                    if (isValidDigit2) {
                        System.out.printf("%d %d %d%n", digit1, digit2, digit3);
                    }
                }
            }
        }
    }
}
