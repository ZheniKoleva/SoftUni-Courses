package L06NestedLoops.moreExercise;

import java.util.Scanner;

public class P05ChallengeTheWedding {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int menCount = Integer.parseInt(scanner.nextLine());
        int womenCount = Integer.parseInt(scanner.nextLine());
        int tablesCount = Integer.parseInt(scanner.nextLine());

        int counter = 0;

        label:
        for (int men = 1; men <= menCount; men++) {
            for (int women = 1; women <= womenCount; women++) {

                System.out.printf("(%d <-> %d) ", men, women);
                counter++;

                if (counter >= tablesCount) {
                    break label;
                }

            }
        }
    }
}
