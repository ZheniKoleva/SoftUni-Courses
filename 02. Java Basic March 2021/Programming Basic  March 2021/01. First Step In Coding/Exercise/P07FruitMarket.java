package L01FirstStepInCoding.exercise;

import java.util.Scanner;

public class P07FruitMarket {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        double strawberryPrice = Double.parseDouble(scanner.nextLine());
        double bananaAmount = Double.parseDouble(scanner.nextLine());
        double orangeAmount = Double.parseDouble(scanner.nextLine());
        double raspberryAmount = Double.parseDouble(scanner.nextLine());
        double strawberryAmount = Double.parseDouble(scanner.nextLine());

        double raspberryPrice = strawberryPrice * 0.50;
        double orangePrice = raspberryPrice * 0.60;
        double bananaPrice = raspberryPrice * 0.20;

        double strawberrySum = strawberryAmount * strawberryPrice;
        double bananaSum = bananaAmount * bananaPrice;
        double orangeSum = orangeAmount * orangePrice;
        double raspberrySum = raspberryAmount * raspberryPrice;

        double finalSum = strawberrySum + bananaSum + orangeSum + raspberrySum;
        System.out.printf("%.2f", finalSum);
    }
}
