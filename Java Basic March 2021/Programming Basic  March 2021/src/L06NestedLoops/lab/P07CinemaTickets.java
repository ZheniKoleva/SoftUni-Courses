package L06NestedLoops.lab;

import java.util.Scanner;

public class P07CinemaTickets {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int studentCount = 0;
        int standardCount = 0;
        int kidCount = 0;
        int ticketsTotal = 0;

        String movieName = scanner.nextLine();
        while (!movieName.equals("Finish")) {
            int freeSeats = Integer.parseInt(scanner.nextLine());
            int ticketsSold = 0;

            String ticketType = scanner.nextLine();
            while (!ticketType.equals("End")) {

                switch (ticketType) {
                    case "student":
                        studentCount++;
                        break;
                    case "standard":
                        standardCount++;
                        break;
                    case "kid":
                        kidCount++;
                        break;
                }
                ticketsTotal++;
                ticketsSold++;
                if (ticketsSold == freeSeats) {
                    break;
                }
                ticketType = scanner.nextLine();
            }
            double percentTaken = (ticketsSold * 1.0 / freeSeats) * 100;
            System.out.printf("%s - %.2f%% full.%n", movieName, percentTaken);

            movieName = scanner.nextLine();
        }

        System.out.printf("Total tickets: %d%n", ticketsTotal);
        System.out.printf("%.2f%% student tickets.%n"
                        + "%.2f%% standard tickets.%n"
                        + "%.2f%% kids tickets.",
                (studentCount * 1.0 / ticketsTotal) * 100,
                (standardCount * 1.0 / ticketsTotal) * 100,
                (kidCount * 1.0 / ticketsTotal) * 100);
    }
}
