package L06NestedLoops.lab;

import java.util.Scanner;

public class P03Combinations {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int number = Integer.parseInt(scanner.nextLine());

        int counter = 0;
        for (int x1 = 0; x1 <= number; x1++) {
            for (int x2 = 0; x2 <= number; x2++) {
                for (int x3 = 0; x3 <= number; x3++) {

                    boolean isValidCombination = x1 + x2 + x3 == number;
                    if (isValidCombination) {
                        counter++;
                    }
                }
            }
        }
        System.out.println(counter);
    }
}
