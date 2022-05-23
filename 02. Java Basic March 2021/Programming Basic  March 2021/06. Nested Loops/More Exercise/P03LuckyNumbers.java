package L06NestedLoops.moreExercise;

import java.util.Scanner;

public class P03LuckyNumbers {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int number = Integer.parseInt(scanner.nextLine());

        for (int d1 = 1; d1 <= 9; d1++) {
            for (int d2 = 1; d2 <= 9; d2++) {
                for (int d3 = 1; d3 <= 9; d3++) {
                    for (int d4 = 1; d4 <= 9; d4++) {

                        boolean isHappyDigit = (d1 + d2 == d3 + d4) && (number % (d1 + d2) == 0);
                        if (isHappyDigit) {
                            System.out.printf("%d%d%d%d ", d1, d2, d3, d4);
                        }
                    }
                }
            }
        }
    }
}
