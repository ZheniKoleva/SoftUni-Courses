package L03ConditionalStatementsAdvanced.moreExercise;

import java.util.Scanner;

public class P01MatchTickets {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        double budget = Double.parseDouble(scanner.nextLine());
        String typeOfTicket = scanner.nextLine();
        int peopleCount = Integer.parseInt(scanner.nextLine());

        double ticketPrice = 0.00;
        double transportExpenses = 0;

        switch (typeOfTicket) {
            case "VIP":
                ticketPrice = 499.99;
                break;
            case "Normal":
                ticketPrice = 249.99;
                break;
        }
        double moneyForTickets = ticketPrice * peopleCount;

        if (peopleCount <= 4) {
            transportExpenses = budget * 0.75;
        } else if (peopleCount <= 9) {
            transportExpenses = budget * 0.60;
        } else if (peopleCount <= 24) {
            transportExpenses = budget * 0.50;
        } else if (peopleCount < 50) {
            transportExpenses = budget * 0.40;
        } else {
            transportExpenses = budget * 0.25;
        }

        budget -= transportExpenses;
        double difference = Math.abs(budget - moneyForTickets);

        if (budget >= moneyForTickets) {
            System.out.printf("Yes! You have %.2f leva left.", difference);
        } else {
            System.out.printf("Not enough money! You need %.2f leva.", difference);
        }
    }
}
