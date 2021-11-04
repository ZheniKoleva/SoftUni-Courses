package L06NestedLoops.moreExercise;

import java.util.Scanner;

public class P11HappyCatParking {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int daysCount = Integer.parseInt(scanner.nextLine());
        int hoursCount = Integer.parseInt(scanner.nextLine());

        double totalSum = 0.0;
        double oddHour = 2.50;
        double evenHour = 1.25;
        double otherHour = 1.0;

        for (int day = 1; day <= daysCount; day++) {

            double sumPerDay = 0;

            for (int hour = 1; hour <= hoursCount; hour++) {

                if (day % 2 == 0 && hour % 2 != 0) {
                    sumPerDay += oddHour;

                }else if (day % 2 != 0 && hour % 2 == 0) {
                    sumPerDay += evenHour;

                }else {
                    sumPerDay += otherHour;
                }
            }

            totalSum += sumPerDay;
            System.out.printf("Day: %d - %.2f leva%n", day, sumPerDay);
        }

        System.out.printf("Total: %.2f leva", totalSum);
    }
}
