package L03ConditionalStatementsAdvanced.moreExercise;

import java.util.Scanner;

public class P03Flowers {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int chrysanthemumsCount = Integer.parseInt(scanner.nextLine());
        int rosesCount = Integer.parseInt(scanner.nextLine());
        int tulipsCounts = Integer.parseInt(scanner.nextLine());
        String season = scanner.nextLine().toLowerCase();
        char holidayOrNot = scanner.nextLine().charAt(0);

        double chrysanthemumPrice = 0.00;
        double rosePrice = 0.00;
        double tulipPrice = 0.00;
        double bouquetArrangement = 2.00;
        double increase = 1.00;
        int flowersCount = chrysanthemumsCount + rosesCount + tulipsCounts;

        switch (season) {
            case "spring":
            case "summer":
                chrysanthemumPrice = 2.00;
                rosePrice = 4.10;
                tulipPrice = 2.50;
                break;
            case "autumn":
            case "winter":
                chrysanthemumPrice = 3.75;
                rosePrice = 4.50;
                tulipPrice = 4.15;
                break;
        }
        if (holidayOrNot == 'Y') {
            increase = 1.15;
        }
        double bouquetPrice = ((chrysanthemumsCount * chrysanthemumPrice) + (rosesCount * rosePrice) +
                (tulipsCounts * tulipPrice)) * increase;

        if (tulipsCounts > 7 && season.equals("spring")) {
            bouquetPrice -= bouquetPrice * 0.05;
        }
        if (rosesCount >= 10 && season.equals("winter")) {
            bouquetPrice -= bouquetPrice * 0.10;
        }
        if (flowersCount > 20) {
            bouquetPrice -= bouquetPrice * 0.20;
        }

        bouquetPrice += bouquetArrangement;
        System.out.printf("%.2f", bouquetPrice);
    }
}
