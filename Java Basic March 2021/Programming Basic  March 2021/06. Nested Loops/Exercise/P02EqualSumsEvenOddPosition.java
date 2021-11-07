package L06NestedLoops.exercise;

import java.util.Scanner;

public class P02EqualSumsEvenOddPosition {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int start = Integer.parseInt(scanner.nextLine());
        int end = Integer.parseInt(scanner.nextLine());

        for (int i = start; i <= end; i++) {
            int currentNum = i;
            int sumEven = 0;
            int sumOdd =0;

            for (int j = 0; j < 6; j++) {

                if (j % 2 == 0) {
                    sumEven += currentNum % 10;
                }else {
                    sumOdd += currentNum % 10;
                }
                currentNum /= 10;
            }

            if (sumEven == sumOdd) {
                System.out.printf("%d ", i);
            }
        }
    }
}
