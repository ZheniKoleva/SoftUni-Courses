package L03ConditionalStatementsAdvanced.exercise;

import java.util.Scanner;

public class P01Cinema {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String projection = scanner.nextLine().toLowerCase();
        int rows = Integer.parseInt(scanner.nextLine());
        int column = Integer.parseInt(scanner.nextLine());

        double priceTicket = 0.00;
        switch (projection) {
            case "premiere":
                priceTicket = 12.00;
                break;
            case "normal":
                priceTicket = 7.50;
                break;
            case "discount":
                priceTicket = 5.00;
                break;
        }

        double totalPrice = (rows * column) * priceTicket;
        System.out.printf("%.2f leva", totalPrice);
    }
}
