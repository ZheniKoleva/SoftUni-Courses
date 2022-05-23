package L04ForLoop.lab;

import java.util.Scanner;

public class P10OddEvenSum {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int numberCount = Integer.parseInt(scanner.nextLine());

        int sumEven = 0;
        int sumOdd = 0;

        for (int i = 0 ; i < numberCount; i++) {
            if (i % 2 == 0) {
                sumEven += Integer.parseInt(scanner.nextLine());
            }else {
                sumOdd += Integer.parseInt(scanner.nextLine());
            }
        }

        if (sumEven == sumOdd) {
            System.out.printf("Yes%n" + "Sum = %d", sumEven);
        }else {
            int difference = Math.abs(sumEven - sumOdd);
            System.out.printf("No%n" + "Diff = %d", difference);
        }
    }
}
