package L06NestedLoops.moreExercise;

import java.util.Scanner;

public class P13PrimePairs {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int startFirstPair = Integer.parseInt(scanner.nextLine());
        int startSecondPair = Integer.parseInt(scanner.nextLine());
        int diffFirst = Integer.parseInt(scanner.nextLine());
        int diffSecond = Integer.parseInt(scanner.nextLine());

        int endFirstPair = startFirstPair + diffFirst;
        int endSecondPair = startSecondPair + diffSecond;

        for (int first = startFirstPair; first <= endFirstPair; first++) {
            for (int second = startSecondPair; second <= endSecondPair; second++) {

                if (first % 2 == 0 || second % 2 == 0) {
                    continue;
                }

                boolean isFirstPrime = true;
                int limitFirst = (int) Math.sqrt(first);
                for (int i = 3; i <= limitFirst; i += 2) {
                    if (first % i == 0) {
                        isFirstPrime = false;
                    }
                }

                boolean isSecondPrime = true;
                int limitSecond = (int) Math.sqrt(second);
                for (int i = 3; i <= limitSecond; i += 2) {
                    if (second % i == 0) {
                        isSecondPrime = false;
                    }
                }

                if (isFirstPrime && isSecondPrime) {
                    System.out.printf("%d%d%n", first, second);
                }
            }
        }
    }
}
