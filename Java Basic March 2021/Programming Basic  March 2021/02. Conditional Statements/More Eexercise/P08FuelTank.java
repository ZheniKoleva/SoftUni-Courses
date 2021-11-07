package L02ConditionalStatements.MoreExercise;

import java.util.Scanner;

public class P08FuelTank {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String typeOfFuel = scanner.nextLine().toLowerCase();
        double fuelQuantity = Double.parseDouble(scanner.nextLine());

        switch (typeOfFuel) {
            case "diesel":
            case "gasoline":
            case "gas":
                if (fuelQuantity >= 25) {
                    System.out.printf("You have enough %s.",typeOfFuel);
                }else {
                    System.out.printf("Fill your tank with %s!", typeOfFuel);
                }
                break;

            default:
                System.out.printf("Invalid fuel!");
                break;
        }
    }
}
