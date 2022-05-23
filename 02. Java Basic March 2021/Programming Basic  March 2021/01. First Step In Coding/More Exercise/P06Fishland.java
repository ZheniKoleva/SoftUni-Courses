package L01FirstStepInCoding.moreExercise;

import java.util.Scanner;

public class P06Fishland {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        double mackerelPrice = Double.parseDouble(scanner.nextLine());
        double toyPrice = Double.parseDouble(scanner.nextLine());
        double bonitoAmount = Double.parseDouble(scanner.nextLine());
        double horseMackerelAmount = Double.parseDouble(scanner.nextLine());
        double musselsAmount = Double.parseDouble(scanner.nextLine());

        double bonitoPrice = mackerelPrice * 1.60;
        double horseMackerelPrice = toyPrice * 1.80;
        double musselsPrice = 7.50;

        double totalSum = (bonitoAmount * bonitoPrice) + (horseMackerelAmount * horseMackerelPrice) +
                (musselsAmount * musselsPrice);
        System.out.printf("%.2f", totalSum);
    }
}
