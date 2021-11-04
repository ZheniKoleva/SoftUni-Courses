package L04ForLoop.lab;

import java.util.Scanner;

public class P09LeftAndRightSum {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int numberPair = Integer.parseInt(scanner.nextLine());

        int firstSum = 0;
        int secondSum = 0;

        for (int i = 0; i < (numberPair * 2) ; i++) {
            if ( i < numberPair) {
                firstSum += Integer.parseInt(scanner.nextLine());
            }else {
                secondSum += Integer.parseInt(scanner.nextLine());
            }
        }

        if (firstSum == secondSum) {
            System.out.printf("Yes, sum = %d", firstSum);
        }else {
            int difference = Math.abs(firstSum - secondSum);
            System.out.printf("No, diff = %d", difference);
        }
    }
}
