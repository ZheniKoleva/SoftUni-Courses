package L06NestedLoops.moreExercise;

import java.util.Scanner;

public class P12TheSongOfTheWheels {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int controlValue = Integer.parseInt(scanner.nextLine());

        boolean isFound = false;
        int counter = 0;
        String forthCombination = "";

        for (int a = 1; a <= 9; a++) {
            for (int b = 1; b <= 9; b++) {
                for (int c = 1; c <= 9; c++) {
                    for (int d = 1; d <= 9; d++) {

                        boolean isValid = ((a * b) + (c * d) == controlValue);
                        boolean isASmaller = a < b;
                        boolean isCBigger = c > d;

                        if (isValid && isASmaller && isCBigger) {
                            System.out.printf("%d%d%d%d ", a, b, c, d);
                            counter++;

                            if (counter == 4) {
                                isFound = true;
                                forthCombination = String.format("Password: %d%d%d%d", a, b, c, d);
                            }
                        }
                    }
                }
            }
        }

        if (isFound) {
            System.out.println();
            System.out.println(forthCombination);

        } else if (counter == 0) {
            System.out.println("No!");

        }else {
            System.out.println();
            System.out.println("No!");
        }
    }
}
