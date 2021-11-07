package L01FirstStepInCoding.lab;

import java.util.Scanner;

public class P08PetShop {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int dogsCount = Integer.parseInt(scanner.nextLine());
        int animalsCount = Integer.parseInt(scanner.nextLine());

        double priceDogFood = 2.50;
        double priceAnimalFood = 4.00;

        double totalSum = (dogsCount * priceDogFood) + (animalsCount * priceAnimalFood);
        System.out.printf("%f lv.", totalSum);
    }
}
