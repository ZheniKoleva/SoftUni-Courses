package L03ConditionalStatementsAdvanced.lab;

import java.util.Scanner;

public class P13SkiTrip {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int daysCount = Integer.parseInt(scanner.nextLine());
        String typeOfRoom = scanner.nextLine();
        String evaluation = scanner.nextLine();

        int night = daysCount - 1;
        double pricePerNight = 0.00;

        switch (typeOfRoom) {
            case "room for one person":
                pricePerNight = 18.00;
                break;
            case "apartment":
                pricePerNight = 25.00;
                break;
            case "president apartment":
                pricePerNight = 35.00;
                break;
        }

        double totalPrice = pricePerNight * night;

        if (daysCount < 10) {
            switch (typeOfRoom) {
                case "apartment":
                    totalPrice -= totalPrice * 0.30;
                    break;
                case "president apartment":
                    totalPrice -= totalPrice * 0.10;
                    break;
            }

        }else if (daysCount >= 10 && daysCount <= 15) {
            switch (typeOfRoom) {
                case "apartment":
                    totalPrice -= totalPrice * 0.35;
                    break;
                case "president apartment":
                    totalPrice -= totalPrice * 0.15;
                    break;
            }

        }else {
            switch (typeOfRoom) {
                case "apartment":
                    totalPrice -= totalPrice * 0.50;
                    break;
                case "president apartment":
                    totalPrice -= totalPrice * 0.20;
                    break;
            }
        }

        switch (evaluation) {
            case "positive":
                totalPrice += totalPrice * 0.25;
                break;
            case "negative":
                totalPrice -= totalPrice * 0.10;
                break;
        }

        System.out.printf("%.2f", totalPrice);
    }
}
