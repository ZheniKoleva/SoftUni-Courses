package L04ForLoop.exercise;

import java.util.Scanner;

public class P02HalfSumElement {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int numberCount = Integer.parseInt(scanner.nextLine());

        int sumNumber = 0;
        int maxNumber = Integer.MIN_VALUE;

        for (int i = 0; i < numberCount; i++) {
            int currentNum = Integer.parseInt(scanner.nextLine());
            sumNumber += currentNum;

            if (currentNum > maxNumber) {
                maxNumber = currentNum;
            }
        }

        sumNumber -= maxNumber;
        if (maxNumber == sumNumber) {
            System.out.printf("Yes%n" + "Sum = %d", maxNumber);
        }else {
            int difference = Math.abs(maxNumber - sumNumber);
            System.out.printf("No%n" + "Diff = %d", difference);
        }
    }
}
