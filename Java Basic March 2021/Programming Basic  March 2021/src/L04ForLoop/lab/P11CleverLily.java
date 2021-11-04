package L04ForLoop.lab;

import java.util.Scanner;

public class P11CleverLily {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int age = Integer.parseInt(scanner.nextLine());
        double washingMachinePrice = Double.parseDouble(scanner.nextLine());
        int pricePerToy = Integer.parseInt(scanner.nextLine());

        double moneySaved = 0;
        int toysCount = 0;
        int moneyGiven = 10;

        for (int i = 1; i <= age ; i++) {
            if (i % 2 == 0) {
                moneySaved += moneyGiven;
                moneyGiven += 10;
                moneySaved--;
            }else {
                toysCount++;
            }
        }
        moneySaved += toysCount * pricePerToy;
        double difference = Math.abs(moneySaved - washingMachinePrice);
        if (moneySaved >= washingMachinePrice) {
            System.out.printf("Yes! %.2f", difference);
        }else {
            System.out.printf("No! %.2f", difference);
        }
    }
}
