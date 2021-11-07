package L06NestedLoops.moreExercise;

import java.util.Scanner;

public class P09SumOfTwoNumbers {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int start = Integer.parseInt(scanner.nextLine());
        int end = Integer.parseInt(scanner.nextLine());
        int magicNum = Integer.parseInt(scanner.nextLine());

        int counter = 0;
        boolean isFound = false;

        label:
        for (int d1 = start; d1 <= end; d1++) {
            for (int d2 = start; d2 <= end; d2++) {

                counter++;
                boolean isValid = d1 + d2 == magicNum;
                if (isValid) {
                    System.out.printf("Combination N:%d (%d + %d = %d)",
                            counter, d1, d2, magicNum);
                    isFound = true;
                    break label;
                }
            }
        }

        if (!isFound) {
            System.out.printf("%d combinations - neither equals %d",
                    counter, magicNum);
        }
    }
}
