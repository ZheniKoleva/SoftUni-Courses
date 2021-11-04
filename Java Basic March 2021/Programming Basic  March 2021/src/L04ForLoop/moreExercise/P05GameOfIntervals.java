package L04ForLoop.moreExercise;

import java.util.Scanner;

public class P05GameOfIntervals {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int gameTurns = Integer.parseInt(scanner.nextLine());

        double points = 0.00;
        int numsTo9 = 0;
        int numsTo19 = 0;
        int numsTo29 = 0;
        int numsTo39 = 0;
        int numsTo50 = 0;
        int invalidNums = 0;

        for (int i = 0; i < gameTurns; i++) {
            int currentNum = Integer.parseInt(scanner.nextLine());

            if (currentNum < 0 || currentNum > 50) {
                invalidNums++;
                points /= 2;
            } else if (currentNum < 10) {
                numsTo9++;
                points += currentNum * 0.20;
            } else if (currentNum < 20) {
                numsTo19++;
                points += currentNum * 0.30;
            } else if (currentNum < 30) {
                numsTo29++;
                points += currentNum * 0.40;
            } else if (currentNum < 40) {
                numsTo39++;
                points += 50;
            } else if (currentNum <= 50) {
                numsTo50++;
                points += 100;
            }
        }

        System.out.printf("%.2f%n", points);
        System.out.printf("From 0 to 9: %.2f%%%n" + "From 10 to 19: %.2f%%%n"
                        + "From 20 to 29: %.2f%%%n" + "From 30 to 39: %.2f%%%n"
                        + "From 40 to 50: %.2f%%%n" + "Invalid numbers: %.2f%%%n",
                (1.0 * numsTo9 / gameTurns * 100), (1.0 * numsTo19 / gameTurns * 100),
                (1.0 * numsTo29 / gameTurns * 100), (1.0 * numsTo39 / gameTurns * 100),
                (1.0 * numsTo50 / gameTurns * 100), (1.0 * invalidNums / gameTurns * 100));
    }
}
