package L01FirstStepInCoding.lab;

import java.util.Scanner;

public class P03SquareArea {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        double side = Double.parseDouble(scanner.nextLine());
        double area = Math.pow(side, 2);
        System.out.printf("%.0f", area);
    }
}
