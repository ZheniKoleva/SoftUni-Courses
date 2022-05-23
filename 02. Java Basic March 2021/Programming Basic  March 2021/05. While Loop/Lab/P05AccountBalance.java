package L05WhileLoop.lab;

import java.util.Scanner;

public class P05AccountBalance {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        double totalMoney = 0.0;
        String command = scanner.nextLine();

        while (!command.equals("NoMoreMoney")) {
            double payment = Double.parseDouble(command);

            if (payment < 0) {
                System.out.println("Invalid operation!");
                break;
            }

            System.out.printf("Increase: %.2f\n", payment);
            totalMoney += payment;
            command = scanner.nextLine();
        }

        System.out.printf("Total: %.2f", totalMoney);
    }
}
