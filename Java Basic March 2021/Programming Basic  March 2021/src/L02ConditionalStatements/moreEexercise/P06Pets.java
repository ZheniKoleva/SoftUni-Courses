package L02ConditionalStatements.MoreExercise;

import java.util.Scanner;

public class P06Pets {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int daysCount = Integer.parseInt(scanner.nextLine());
        int foodLeftInKg = Integer.parseInt(scanner.nextLine());
        double foodEatenByDog = Double.parseDouble(scanner.nextLine());
        double foodEatenByCat = Double.parseDouble(scanner.nextLine());
        double foodEatenByTurtleGr = Double.parseDouble(scanner.nextLine());

        double foodEaten = (foodEatenByDog + foodEatenByCat + (foodEatenByTurtleGr / 1000)) * daysCount;
        double difference = Math.abs(foodLeftInKg - foodEaten);

        if (foodEaten <= foodLeftInKg) {
            System.out.printf("%.0f kilos of food left.", Math.floor(difference));
        }else {
            System.out.printf("%.0f more kilos of food are needed.", Math.ceil(difference));
        }
    }
}
