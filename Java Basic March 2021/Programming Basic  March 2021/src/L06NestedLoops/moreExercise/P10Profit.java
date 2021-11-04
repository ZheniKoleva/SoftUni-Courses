package L06NestedLoops.moreExercise;

import java.util.Scanner;

public class P10Profit {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int coins1Lv = Integer.parseInt(scanner.nextLine());
        int coins2Lv = Integer.parseInt(scanner.nextLine());
        int notes5Lv = Integer.parseInt(scanner.nextLine());
        int sum = Integer.parseInt(scanner.nextLine());

        for (int one = 0; one <= coins1Lv; one++) {
            for (int two = 0; two <= coins2Lv; two++) {
                for (int five = 0; five <= notes5Lv; five++) {

                    boolean isValid = (one * 1) + (two * 2) + (five * 5) == sum;
                    if (isValid) {
                        System.out.printf("%d * 1 lv. + %d * 2 lv. + %d * 5 lv. = %d lv.%n",
                                one, two, five, sum);
                    }

                }
            }
        }
    }
}
