package L04ForLoop.exercise;

import java.util.Scanner;

public class P05DivideWithoutRemainder {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int numberCount = Integer.parseInt(scanner.nextLine());

        int p1 = 0;
        int p2 = 0;
        int p3 = 0;

        for (int i = 0; i < numberCount; i++) {
            int currentNum = Integer.parseInt(scanner.nextLine());
            if (currentNum % 2 == 0) {
                p1++;
            }
            if (currentNum % 3 == 0) {
                p2++;
            }
            if (currentNum % 4 == 0) {
                p3++;
            }
        }
        double percentP1 = (1.0 * p1 / numberCount * 100);
        double percentP2 = (1.0 * p2 / numberCount * 100);
        double percentP3 = (1.0 * p3 / numberCount * 100);
        System.out.printf("%.2f%%%n" + "%.2f%%%n" + "%.2f%%%n",
                percentP1, percentP2, percentP3);
    }
}
