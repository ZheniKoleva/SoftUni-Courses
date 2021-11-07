package L03ConditionalStatementsAdvanced.moreExercise;

import java.util.Scanner;

public class P05Vacation {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        double budget = Double.parseDouble(scanner.nextLine());
        String season = scanner.nextLine().toLowerCase();

        String destination = null;
        String accommodation = null;
        double price = 0.00;

        if (budget <= 1000) {
            accommodation = "Camp";
            switch (season) {
                case "summer":
                    destination = "Alaska";
                    price = budget * 0.65;
                    break;
                case "winter":
                    destination = "Morocco";
                    price = budget * 0.45;
                    break;
            }
        }else if (budget <= 3000) {
            accommodation = "Hut";
            switch (season) {
                case "summer":
                    destination = "Alaska";
                    price = budget * 0.80;
                    break;
                case "winter":
                    destination = "Morocco";
                    price = budget * 0.60;
                    break;
            }
        }else {
            accommodation= "Hotel";
            price = budget * 0.90;
            switch (season) {
                case "summer":
                    destination = "Alaska";
                    break;
                case "winter":
                    destination = "Morocco";
                    break;
            }
        }

        System.out.printf("%s - %s - %.2f", destination, accommodation, price);
    }
}
