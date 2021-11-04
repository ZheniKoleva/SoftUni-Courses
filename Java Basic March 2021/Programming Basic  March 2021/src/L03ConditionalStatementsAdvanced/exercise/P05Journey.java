package L03ConditionalStatementsAdvanced.exercise;

import java.util.Scanner;

public class P05Journey {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        double budget = Double.parseDouble(scanner.nextLine());
        String season = scanner.nextLine().toLowerCase();

        double moneySpend = 0.00;
        String destination = null;
        String accommodation = null;

        if (budget <= 100) {
            destination = "Bulgaria";
            accommodation = season.equals("summer") ? "Camp" : "Hotel";
            moneySpend = season.equals("summer") ? budget * 0.30 : budget * 0.70;
        }else if (budget <= 1000) {
            destination = "Balkans";
            accommodation = season.equals("summer") ? "Camp" : "Hotel";
            moneySpend = season.equals("summer") ? budget * 0.40 : budget * 0.80;
        }else {
            destination = "Europe";
            accommodation = "Hotel";
            moneySpend = budget * 0.90;
        }
        System.out.printf("Somewhere in %s\n" +
                           "%s - %.2f", destination, accommodation, moneySpend);
    }
}
