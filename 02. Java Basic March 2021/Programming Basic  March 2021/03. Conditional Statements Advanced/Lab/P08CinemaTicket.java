package L03ConditionalStatementsAdvanced.lab;

import java.util.Scanner;

public class P08CinemaTicket {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String dayOfWeek = scanner.nextLine();
        int ticketPrice = 0;

        switch (dayOfWeek.toLowerCase()) {
            case "monday":
            case "tuesday":
            case "friday":
                ticketPrice = 12;
                break;
            case "wednesday":
            case "thursday":
                ticketPrice = 14;
                break;
            case "saturday":
            case "sunday":
                ticketPrice = 16;
                break;
        }
        System.out.println(ticketPrice);
    }
}
