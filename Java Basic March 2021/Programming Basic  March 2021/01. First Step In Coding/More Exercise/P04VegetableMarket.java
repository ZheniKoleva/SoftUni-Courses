package L01FirstStepInCoding.moreExercise;

import java.util.Scanner;

public class P04VegetableMarket {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        double vegetablesPrice = Double.parseDouble(scanner.nextLine());
        double fruitsPrice = Double.parseDouble(scanner.nextLine());
        int vegetablesAmount = Integer.parseInt(scanner.nextLine());
        int fruitsAmount = Integer.parseInt(scanner.nextLine());

        double profitInBgn = (vegetablesAmount * vegetablesPrice) + (fruitsAmount * fruitsPrice);
        double profitInEur = profitInBgn / 1.94;
        System.out.printf("%.2f", profitInEur);
    }
}
