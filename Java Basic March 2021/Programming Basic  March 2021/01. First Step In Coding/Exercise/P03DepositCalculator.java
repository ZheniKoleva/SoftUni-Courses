package L01FirstStepInCoding.exercise;

import java.util.Scanner;

public class P03DepositCalculator {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        double depositedSum = Double.parseDouble(scanner.nextLine());
        int term = Integer.parseInt(scanner.nextLine());
        double interest = Double.parseDouble(scanner.nextLine());

        double monthlySum = (depositedSum * (interest / 100)) / 12;
        depositedSum += monthlySum * term;

        System.out.println(depositedSum);
    }
}
