package L02ConditionalStatements.Lab;

import java.util.Scanner;

public class P03EvenOrOdd {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int number = Integer.parseInt(scanner.nextLine());
        String isEvenOrOdd = number % 2 == 0 ? "even" : "odd";
        System.out.println(isEvenOrOdd);
    }
}
