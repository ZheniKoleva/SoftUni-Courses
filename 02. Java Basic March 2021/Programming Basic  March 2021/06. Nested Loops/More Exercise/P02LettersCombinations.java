package L06NestedLoops.moreExercise;

import java.util.Scanner;

public class P02LettersCombinations {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        char start = scanner.nextLine().charAt(0);
        char end = scanner.nextLine().charAt(0);
        char excludedLetter = scanner.nextLine().charAt(0);

        int counter = 0;

        for (char i = start; i <= end; i++) {
            for (int j = start; j <= end; j++) {
                for (int k = start; k <= end; k++) {

                    boolean isNotValid = i == excludedLetter
                            || j == excludedLetter
                            || k == excludedLetter;
                    if (isNotValid) {
                        continue;
                    }
                    counter++;
                    System.out.printf("%c%c%c ", i, j, k);
                }
            }
        }

        System.out.println(counter);
    }
}
