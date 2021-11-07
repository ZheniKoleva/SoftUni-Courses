package L01FirstStepInCoding.lab;

import java.util.Scanner;

public class P04InchesToCentimeters {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        double inches = Double.parseDouble(scanner.nextLine());
        double rate = 2.54;
        double cm = inches * rate;
        System.out.println(cm);
    }
}
