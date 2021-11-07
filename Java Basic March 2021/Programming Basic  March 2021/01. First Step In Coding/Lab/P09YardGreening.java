package L01FirstStepInCoding.lab;

import java.util.Scanner;

public class P09YardGreening {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        double areaToGreen = Double.parseDouble(scanner.nextLine());
        double pricePerSqMeter = 7.61;
        double discountPercent = 0.18;

        double totalSum = pricePerSqMeter * areaToGreen;
        double discount = totalSum * 0.18;
        totalSum -= discount;
        System.out.printf("The final price is: %f lv.\nThe discount is: %f lv.", totalSum, discount);
    }
}
