package L02ConditionalStatements.MoreExercise;

import java.util.Scanner;

public class P08FuelTankPart2 {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String typeOfFuel = scanner.nextLine().toLowerCase();
        double fuelQuantity = Double.parseDouble(scanner.nextLine());
        String hasClubCard = scanner.nextLine();

        double gasolinePrice = 2.22;
        double dieselPrice = 2.33;
        double gasPrice = 0.93;

        if (hasClubCard.equalsIgnoreCase("yes")) {
            gasolinePrice -= 0.18;
            dieselPrice -= 0.12;
            gasPrice -= 0.08;
        }

        double totalSum = 0.00;
        switch (typeOfFuel) {
            case "gasoline":
                totalSum = gasolinePrice * fuelQuantity;
                break;
            case "diesel":
                totalSum = dieselPrice * fuelQuantity;
                break;
            case "gas":
                totalSum = gasPrice * fuelQuantity;
                break;
        }

        if (fuelQuantity >= 20 && fuelQuantity <= 25 ) {
            totalSum -= totalSum * 0.08;
        }else if (fuelQuantity > 25) {
            totalSum -= totalSum * 0.10;
        }

        System.out.printf("%.2f lv.", totalSum);
    }
}
