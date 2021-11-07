package L05WhileLoop.exercise;

import java.util.Scanner;

public class P04Walking {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int stepsGoal = 10000;

        boolean isReached = false;

        String command = scanner.nextLine();
        while (!command.equals("Going home")) {
            stepsGoal -= Integer.parseInt(command);

            if (stepsGoal <= 0) {
                isReached = true;
                break;
            }
            command = scanner.nextLine();
        }

        if (command.equals("Going home")) {
            stepsGoal -= Integer.parseInt(scanner.nextLine());
            if (stepsGoal <= 0) {
                isReached = true;
            }
        }
        if (isReached) {
            System.out.printf("Goal reached! Good job!%n"
                    + "%d steps over the goal!", Math.abs(stepsGoal));
        } else {
            System.out.printf("%d more steps to reach goal.", stepsGoal);
        }
    }
}
