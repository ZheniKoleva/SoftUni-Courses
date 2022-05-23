package L05WhileLoop.moreExercise;

import java.util.Scanner;

public class P05AverageNumber {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int number = Integer.parseInt(scanner.nextLine());
        double sum = 0.0;

        for (int i = 0; i < number; i++) {
            sum += Integer.parseInt(scanner.nextLine());
        }

        System.out.printf("%.2f", sum / number);
    }
}
