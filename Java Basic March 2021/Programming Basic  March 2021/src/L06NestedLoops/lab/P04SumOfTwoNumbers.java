package L06NestedLoops.lab;

import java.util.Scanner;

public class P04SumOfTwoNumbers {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int start = Integer.parseInt(scanner.nextLine());
        int end = Integer.parseInt(scanner.nextLine());
        int magicNumber = Integer.parseInt(scanner.nextLine());
        
        int combinationCounter = 0;
        boolean isNotFound = true;

        label:
        for (int x1 = start; x1 <= end; x1++) {
            for (int x2 = start; x2 <= end; x2++) {
                combinationCounter++;
                boolean isValid = x1 + x2 == magicNumber;

                if (isValid) {
                    System.out.printf("Combination N:%d (%d + %d = %d)",
                            combinationCounter, x1, x2, magicNumber);
                    isNotFound = false;
                    break label;
                }
            }
        }
        if (isNotFound) {
            System.out.printf("%d combinations - neither equals %d",
                    combinationCounter,magicNumber);
        }
    }
}
