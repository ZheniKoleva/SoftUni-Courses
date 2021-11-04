package L03ConditionalStatementsAdvanced.exercise;

import java.util.Scanner;

public class P04FishingBoat {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        double budget = Double.parseDouble(scanner.nextLine());
        String season = scanner.nextLine().toLowerCase();
        int fishermenCount = Integer.parseInt(scanner.nextLine());

        double rent = 0.00;
        switch (season) {
            case "spring":
                rent = 3000.00;
                break;
            case "summer":
            case "autumn":
                rent = 4200.00;
                break;
            case "winter":
                rent = 2600.00;
                break;
        }

        if (fishermenCount <= 6) {
            rent -= rent * 0.10;
        }else if (fishermenCount <= 11) {
            rent -= rent * 0.15;
        }else {
            rent -= rent * 0.25;
        }

        if (fishermenCount % 2 == 0 && !season.equals("autumn")) {
            rent -= rent * 0.05;
        }
        double difference = Math.abs(budget - rent);
        if (budget >= rent) {
            System.out.printf("Yes! You have %.2f leva left.", difference);
        }else {
            System.out.printf("Not enough money! You need %.2f leva.", difference);
        }
    }
}
