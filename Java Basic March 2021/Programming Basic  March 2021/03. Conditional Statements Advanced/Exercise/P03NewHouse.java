package L03ConditionalStatementsAdvanced.exercise;

import java.util.Scanner;

public class P03NewHouse {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String flowers = scanner.nextLine();
        int flowerCount = Integer.parseInt(scanner.nextLine());
        double budget = Double.parseDouble(scanner.nextLine());

        double flowerPrice = 0.00;
        switch (flowers) {
            case "Roses":
                flowerPrice = 5.00;
                if (flowerCount > 80) {
                    flowerPrice -= flowerPrice * 0.10;
                }
                break;
            case "Dahlias":
                flowerPrice = 3.80;
                if (flowerCount > 90) {
                    flowerPrice -= flowerPrice * 0.15;
                }
                break;
            case "Tulips":
                flowerPrice = 2.80;
                if (flowerCount > 80) {
                    flowerPrice -= flowerPrice * 0.15;
                }
                break;
            case "Narcissus":
                flowerPrice = 3.00;
                if (flowerCount < 120) {
                    flowerPrice += flowerPrice * 0.15;
                }
                break;
            case "Gladiolus":
                flowerPrice = 2.50;
                if (flowerCount < 80) {
                    flowerPrice += flowerPrice * 0.20;
                }
                break;
        }

        double totalSum = flowerCount * flowerPrice;
        double difference = Math.abs(budget - totalSum);
        if (budget >= totalSum) {
            System.out.printf("Hey, you have a great garden with %d %s and %.2f leva left.",
                    flowerCount, flowers, difference);
        }else {
            System.out.printf("Not enough money, you need %.2f leva more.", difference);
        }
    }
}
