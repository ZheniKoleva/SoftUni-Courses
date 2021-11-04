import java.util.Scanner;

public class P04CatFood {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int catsCount = Integer.parseInt(scanner.nextLine());

        int group1 = 0;
        int group2 = 0;
        int group3 = 0;
        double foodPricePerKg = 12.45;
        double foodEatenInGrams = 0;

        for (int i = 0; i < catsCount; i++) {
            double currentFoodEaten = Double.parseDouble(scanner.nextLine());;
            foodEatenInGrams += currentFoodEaten;

            if (currentFoodEaten < 200) {
                group1++;

            } else if (currentFoodEaten < 300) {
                group2++;

            } else if (currentFoodEaten < 400) {
                group3++;
            }
        }

        double totalPriceForFood = (foodEatenInGrams / 1000) * foodPricePerKg;

        System.out.printf("Group 1: %d cats.\n"
                        + "Group 2: %d cats.\n"
                        + "Group 3: %d cats.\n"
                        + "Price for food per day: %.2f lv.",
                group1, group2, group3, totalPriceForFood);
    }
}
