package L02ConditionalStatements.MoreExercise;

import java.util.Scanner;

public class P01PipesInPool {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int poolVolume = Integer.parseInt(scanner.nextLine());
        int debitP1 = Integer.parseInt(scanner.nextLine());
        int debitP2 = Integer.parseInt(scanner.nextLine());
        double hours = Double.parseDouble(scanner.nextLine());

        double filledByP1 = debitP1 * hours;
        double filledByP2 = debitP2 * hours;
        double volumeByPipes = filledByP1 + filledByP2;
        double percentFilled = (volumeByPipes / poolVolume) * 100;
        double percentByP1 = (filledByP1 / volumeByPipes) * 100;
        double percentByP2 = (filledByP2 / volumeByPipes) * 100;

        if (volumeByPipes <= poolVolume) {
            System.out.printf("The pool is %.2f%% full. Pipe 1: %.2f%%. Pipe 2: %.2f%%.",
                    percentFilled, percentByP1, percentByP2);
        }else {
            System.out.printf("For %.2f hours the pool overflows with %.2f liters.",
                    hours, (volumeByPipes - poolVolume));
        }
    }
}
