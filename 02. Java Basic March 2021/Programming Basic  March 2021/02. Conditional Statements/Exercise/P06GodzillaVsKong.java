package L02ConditionalStatements.Exercise;

import java.util.Scanner;

public class P06GodzillaVsKong {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        double budget = Double.parseDouble(scanner.nextLine());
        int extrasCount = Integer.parseInt(scanner.nextLine());
        double clothPricePerOne = Double.parseDouble(scanner.nextLine());

        double decor = budget * 0.10;

        if (extrasCount > 150) {
            clothPricePerOne -= clothPricePerOne * 0.10;
        }

        double totalSum = (clothPricePerOne * extrasCount) + decor;
        double difference = Math.abs(budget - totalSum);

        if (totalSum <= budget) {
            System.out.printf("Action!\nWingard starts filming with %.2f leva left.", difference);
        }else {
            System.out.printf("Not enough money!\nWingard needs %.2f leva more.", difference);
        }
    }
}
