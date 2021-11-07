package L04ForLoop.exercise;

import java.util.Scanner;

public class P04Histogram {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int numberCount = Integer.parseInt(scanner.nextLine());

        int p1 = 0;
        int p2 = 0;
        int p3 = 0;
        int p4 = 0;
        int p5 = 0;

        for (int i = 0; i < numberCount; i++) {
            int currentNum = Integer.parseInt(scanner.nextLine());
            if (currentNum < 200) {
                p1++;
            } else if (currentNum < 400) {
                p2++;
            } else if (currentNum < 600) {
                p3++;
            } else if (currentNum < 800) {
                p4++;
            } else {
                p5++;
            }
        }
        double percentP1 = (1.0 * p1 / numberCount * 100);
        double percentP2 = (1.0 * p2 / numberCount * 100);
        double percentP3 = (1.0 * p3 / numberCount * 100);
        double percentP4 = (1.0 * p4 / numberCount * 100);
        double percentP5 = (1.0 * p5 / numberCount * 100);
        System.out.printf("%.2f%%%n" + "%.2f%%%n" + "%.2f%%%n" + "%.2f%%%n" + "%.2f%%",
                percentP1, percentP2, percentP3, percentP4, percentP5);
    }
}
