package L03ConditionalStatementsAdvanced.lab;

import java.util.Scanner;

public class P11FruitShop {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String fruit = scanner.nextLine();
        String dayOfWeek = scanner.nextLine();
        double quantity = Double.parseDouble(scanner.nextLine());

        double price = 0.00;
        boolean isWeekend = dayOfWeek.equals("Saturday") || dayOfWeek.equals("Sunday");
        boolean isWorkingDay = dayOfWeek.equals("Monday") || dayOfWeek.equals("Tuesday")
                               || dayOfWeek.equals("Wednesday") || dayOfWeek.equals("Thursday")
                               || dayOfWeek.equals("Friday");

        if (isWorkingDay) {
            switch (fruit) {
                case "banana":
                    price = 2.50;
                    break;
                case "apple":
                    price = 1.20;
                    break;
                case "orange":
                    price = 0.85;
                    break;
                case "grapefruit":
                    price = 1.45;
                    break;
                case "kiwi":
                    price = 2.70;
                    break;
                case "pineapple":
                    price = 5.50;
                    break;
                case "grapes":
                    price = 3.85;
                    break;
                default:
                    System.out.println("error");
                    break;
            }
        }else if (isWeekend) {
            switch (fruit) {
                case "banana":
                    price = 2.70;
                    break;
                case "apple":
                    price = 1.25;
                    break;
                case "orange":
                    price = 0.90;
                    break;
                case "grapefruit":
                    price = 1.60;
                    break;
                case "kiwi":
                    price = 3.00;
                    break;
                case "pineapple":
                    price = 5.60;
                    break;
                case "grapes":
                    price = 4.20;
                    break;
                default:
                    System.out.println("error");
                    break;
            }
        }else {
            System.out.println("error");
        }

        if (price != 0) {
            double totalPrice = quantity * price;
            System.out.printf("%.2f", totalPrice);
        }
    }
}
