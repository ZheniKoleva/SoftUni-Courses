package L03ConditionalStatementsAdvanced.moreExercise;

import java.util.Scanner;

public class P06TruckDriver {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String season = scanner.nextLine().toLowerCase();
        double kmPerMonth = Double.parseDouble(scanner.nextLine());

        int monthInSeason = 4;
        double wagePerKm = 0.00;

        if (kmPerMonth <= 5000) {
            switch (season) {
                case "spring":
                case "autumn":
                    wagePerKm = 0.75;
                    break;
                case "summer":
                    wagePerKm = 0.90;
                    break;
                case "winter":
                    wagePerKm = 1.05;
                    break;
            }

        }else if (kmPerMonth <= 10000) {
            switch (season) {
                case "spring":
                case "autumn":
                    wagePerKm = 0.95;
                    break;
                case "summer":
                    wagePerKm = 1.10;
                    break;
                case "winter":
                    wagePerKm = 1.25;
                    break;
            }
        }else if (kmPerMonth <= 20000) {
            wagePerKm = 1.45;
        }

        double profit = kmPerMonth * wagePerKm * monthInSeason;
        profit -= profit * 0.10;
        System.out.printf("%.2f", profit);
    }
}
