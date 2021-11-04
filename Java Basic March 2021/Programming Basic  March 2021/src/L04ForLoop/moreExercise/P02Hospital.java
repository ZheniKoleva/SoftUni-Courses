package L04ForLoop.moreExercise;

import java.util.Scanner;

public class P02Hospital {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int daysCount = Integer.parseInt(scanner.nextLine());

        int treated = 0;
        int untreated = 0;
        int doctorsCount = 7;

        for (int i = 1; i <= daysCount ; i++) {
            int patientCount = Integer.parseInt(scanner.nextLine());

            if (i % 3 == 0 && untreated > treated) {
                doctorsCount++;
            }
            if (patientCount <= doctorsCount) {
                treated += patientCount;
            }else {
                treated += doctorsCount;
                untreated += (patientCount - doctorsCount);
            }
        }

        System.out.printf("Treated patients: %d.%n" + "Untreated patients: %d.",
                treated, untreated);
    }
}
