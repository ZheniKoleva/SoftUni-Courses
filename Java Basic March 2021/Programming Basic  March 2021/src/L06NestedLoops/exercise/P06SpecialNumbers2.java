package L06NestedLoops.exercise;

import java.util.Scanner;

public class P06SpecialNumbers2 {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int number = Integer.parseInt(scanner.nextLine());

        for (int num = 1111; num <= 9999; num++) {

            int currentNum = num;
            boolean isValid = true;

            for (int i = 0; i < 4; i++) {

                if (number % (currentNum % 10) != 0) {
                    isValid = false;
                    break;
                }
                currentNum /= 10;
            }

            if (isValid) {
                System.out.printf("%d ", num);
            }
        }
    }
}

