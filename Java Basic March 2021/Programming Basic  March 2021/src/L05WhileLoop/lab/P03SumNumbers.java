package L05WhileLoop.lab;

import java.util.Scanner;

public class P03SumNumbers {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int number = Integer.parseInt(scanner.nextLine());

        int sum = 0;

        while (sum < number) {
            sum += Integer.parseInt(scanner.nextLine());
        }

        System.out.println(sum);
    }
}
