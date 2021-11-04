package L06NestedLoops.exercise;

import java.util.Scanner;

public class P06SpecialNumbers {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int number = Integer.parseInt(scanner.nextLine());

        for (int d1 = 1; d1 <= 9; d1++) {
            for (int d2 = 1; d2 <= 9; d2++) {
                for (int d3 = 1; d3 <= 9; d3++) {
                    for (int d4 = 1; d4 <= 9; d4++) {

                        boolean isValid = number % d1 == 0 && number % d2 == 0
                                && number % d3 == 0 && number % d4 == 0;

                        if (isValid) {
                            System.out.printf("%d%d%d%d ", d1, d2, d3, d4);
                        }

                    }
                }
            }
        }
    }
}
