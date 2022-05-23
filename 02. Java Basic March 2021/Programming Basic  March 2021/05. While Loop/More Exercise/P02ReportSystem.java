package L05WhileLoop.moreExercise;

import java.util.Scanner;

public class P02ReportSystem {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int moneyToCollect = Integer.parseInt(scanner.nextLine());

        int counter = 0;
        int inCashCount = 0;
        double sumInCash = 0;
        int byCardCount = 0;
        double sumByCard = 0;
        boolean isCollect = false;

        String command = scanner.nextLine();
        while (!command.equals("End")) {
            int itemsPrice = Integer.parseInt(command);

            if (counter % 2 == 0) {
                if (itemsPrice > 100) {
                    System.out.println("Error in transaction!");
                } else {
                    inCashCount++;
                    sumInCash += itemsPrice;
                    moneyToCollect -= itemsPrice;
                    System.out.println("Product sold!");
                }

            } else {
                if (itemsPrice < 10) {
                    System.out.println("Error in transaction!");

                } else {
                    byCardCount++;
                    sumByCard += itemsPrice;
                    moneyToCollect -= itemsPrice;
                    System.out.println("Product sold!");
                }
            }

            if (moneyToCollect <= 0) {
                isCollect = true;
                break;
            }
            counter++;
            command = scanner.nextLine();
        }

        if (isCollect) {
            System.out.printf("Average CS: %.2f%n"
                            + "Average CC: %.2f",
                    sumInCash / inCashCount, sumByCard / byCardCount);
        } else {
            System.out.println("Failed to collect required money for charity.");
        }
    }
}
