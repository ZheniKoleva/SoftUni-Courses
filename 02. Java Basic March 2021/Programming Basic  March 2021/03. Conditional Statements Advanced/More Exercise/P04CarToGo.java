package L03ConditionalStatementsAdvanced.moreExercise;

import java.util.Scanner;

public class P04CarToGo {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        double budget = Double.parseDouble(scanner.nextLine());
        String season = scanner.nextLine().toLowerCase();

        String carClass = null;
        String carType = null;
        double price = 0.00;

        if (budget <= 100) {
            carClass = "Economy class";
            switch (season) {
                case "summer":
                    carType = "Cabrio";
                    price = budget * 0.35;
                    break;
                case "winter":
                    carType = "Jeep";
                    price = budget * 0.65;
                    break;
            }
        }else if (budget <= 500) {
            carClass = "Compact class";
            switch (season) {
                case "summer":
                    carType = "Cabrio";
                    price = budget * 0.45;
                    break;
                case "winter":
                    carType = "Jeep";
                    price = budget * 0.80;
                    break;
            }
        }else {
            carClass = "Luxury class";
            carType = "Jeep";
            price = budget * 0.90;
        }

        System.out.printf("%s%n%s - %.2f", carClass, carType, price);
    }
}
