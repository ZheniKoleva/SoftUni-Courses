package L05WhileLoop.moreExercise;

import java.util.Scanner;

public class P01Dishwasher {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int bottlesCount = Integer.parseInt(scanner.nextLine());

        int bottleQuantity = 750;
        int detergentPerDish = 5;
        int detergentPerPot = 15;
        int detergentTotal = bottleQuantity * bottlesCount;

        int dishesWashed = 0;
        int potsWashed = 0;
        int counter = 0;
        boolean isDetergentFinished = false;

        String command = scanner.nextLine();
        while (!command.equals("End")) {
            int dishesCount = Integer.parseInt(command);
            counter++;

            if (counter % 3 == 0) {
                detergentTotal -= dishesCount * detergentPerPot;
                potsWashed += dishesCount;

            } else {
                detergentTotal -= dishesCount * detergentPerDish;
                dishesWashed += dishesCount;
            }

            if (detergentTotal < 0) {
                isDetergentFinished = true;
                break;
            }

            command = scanner.nextLine();
        }

        if (isDetergentFinished) {
            System.out.printf("Not enough detergent, %d ml. more necessary!",
                    Math.abs(detergentTotal));

        } else {
            System.out.printf("Detergent was enough!%n"
                            + "%d dishes and %d pots were washed.%n"
                            + "Leftover detergent %d ml.",
                    dishesWashed, potsWashed, detergentTotal);
        }
    }
}
