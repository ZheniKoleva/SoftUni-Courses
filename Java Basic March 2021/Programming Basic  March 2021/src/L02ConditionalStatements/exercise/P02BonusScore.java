package L02ConditionalStatements.Exercise;

import java.util.Scanner;

public class P02BonusScore {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int number = Integer.parseInt(scanner.nextLine());
        double bonusPoints = 0.00;

        if (number <= 100) {
            bonusPoints = 5;
        }else if (number <= 1000) {
            bonusPoints = number * 0.20;
        }else {
            bonusPoints = number * 0.10;
        }

        if (number % 2 == 0) {
            bonusPoints += 1;
        }else if (number % 10 == 5) {
            bonusPoints += 2;
        }

        System.out.printf("%.1f\n%.1f",bonusPoints, number + bonusPoints);
    }
}
