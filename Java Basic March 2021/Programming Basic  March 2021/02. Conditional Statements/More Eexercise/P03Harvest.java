package L02ConditionalStatements.MoreExercise;

import java.util.Scanner;

public class P03Harvest {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int wineYard = Integer.parseInt(scanner.nextLine());
        double grapesPerSqMeter = Double.parseDouble(scanner.nextLine());
        int wineNeeded = Integer.parseInt(scanner.nextLine());
        int workersCount = Integer.parseInt(scanner.nextLine());

        double harvest = (wineYard * grapesPerSqMeter) * 0.40;
        double wineProduced = harvest / 2.5;
        double difference = Math.abs(wineProduced - wineNeeded);

        if (wineNeeded > wineProduced) {
            System.out.printf("It will be a tough winter! More %.0f liters wine needed.", Math.floor(difference));
        }else {
            double winePerWorker = Math.ceil(difference / workersCount);
            System.out.printf("Good harvest this year! Total wine: %.0f liters.\n", Math.floor(wineProduced));
            System.out.printf("%.0f liters left -> %.0f liters per person.", Math.ceil(difference), winePerWorker);
        }
    }
}
