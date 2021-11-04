package L02ConditionalStatements.Lab;

import java.util.Scanner;

public class P07ToyShop {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        double tripPrice = Double.parseDouble(scanner.nextLine());
        int puzzleCount = Integer.parseInt(scanner.nextLine());
        int dollCount = Integer.parseInt(scanner.nextLine());
        int bearCount = Integer.parseInt(scanner.nextLine());
        int minionCount = Integer.parseInt(scanner.nextLine());
        int truckCount = Integer.parseInt(scanner.nextLine());

        double puzzlePrice = 2.60;
        double dollPrice = 3.00;
        double bearPrice = 4.10;
        double minionPrice = 8.20;
        double truckPrice = 2.00;

        int toysCount = puzzleCount + dollCount + bearCount + minionCount + truckCount;
        double totalSum = (puzzleCount * puzzlePrice) + (dollCount * dollPrice) + (bearCount * bearPrice) +
                (minionCount * minionPrice) + (truckCount * truckPrice);

        if (toysCount >= 50) {
            totalSum -= totalSum * 0.25;
        }

        totalSum -= totalSum * 0.10;
        double difference = Math.abs(totalSum - tripPrice);

        if (totalSum >= tripPrice) {
            System.out.printf("Yes! %.2f lv left.", difference);
        }else {
            System.out.printf("Not enough money! %.2f lv needed.", difference);
        }
    }
}
