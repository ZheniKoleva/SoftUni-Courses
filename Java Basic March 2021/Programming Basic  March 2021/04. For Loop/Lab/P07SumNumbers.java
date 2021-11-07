package L04ForLoop.lab;

import java.util.Scanner;

public class P07SumNumbers {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int numberCount = Integer.parseInt(scanner.nextLine());

        int sumNumbers = 0;
        for (int i = 0; i < numberCount ; i++) {
            sumNumbers += Integer.parseInt(scanner.nextLine());
        }

        System.out.printf("%d", sumNumbers);
    }
}
