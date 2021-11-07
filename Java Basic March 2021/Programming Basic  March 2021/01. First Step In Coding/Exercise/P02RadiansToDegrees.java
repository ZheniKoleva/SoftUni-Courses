package L01FirstStepInCoding.exercise;

import java.util.Scanner;

public class P02RadiansToDegrees {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        double radians = Double.parseDouble(scanner.nextLine());
        double degrees = Math.toDegrees(radians);
        System.out.printf("%.0f", degrees);
    }
}
