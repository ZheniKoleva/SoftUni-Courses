package L02ConditionalStatements.MoreExercise;

import java.util.Scanner;

public class P04TransportPrice {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int distance = Integer.parseInt(scanner.nextLine());
        String dayOrNight = scanner.nextLine();

        double initialTaxiFee = 0.70;
        double taxiRate = 0.00;

        switch (dayOrNight) {
            case "day": taxiRate = 0.79; break;
            case "night": taxiRate = 0.90;break;
        }

        double busRate = 0.09;
        double trainRate = 0.06;
        double totalSum = 0.00;

        if (distance < 20) {
            totalSum = initialTaxiFee + (distance * taxiRate);
        }else if (distance < 100) {
            totalSum = distance * busRate;
        }else {
            totalSum = distance * trainRate;
        }

        System.out.printf("%.2f", totalSum);
    }
}
