package L01FirstStepInCoding.exercise;

import java.util.Scanner;

public class P05BirthdayParty {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int rent = Integer.parseInt(scanner.nextLine());

        double cakePrice = rent * 0.20;
        double drinksPrice = cakePrice * 0.55;
        double animator = rent / 3.0;

        double finalSum = rent + cakePrice + drinksPrice + animator;
        System.out.println(finalSum);
    }
}
