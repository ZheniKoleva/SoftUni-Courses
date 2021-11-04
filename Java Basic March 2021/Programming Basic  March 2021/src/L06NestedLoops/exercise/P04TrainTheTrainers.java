package L06NestedLoops.exercise;

import java.util.Scanner;

public class P04TrainTheTrainers {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int juryCount = Integer.parseInt(scanner.nextLine());

        double sumAllGrades = 0.0;
        int presentationsCount = 0;

        String presentationName = scanner.nextLine();
        while (!presentationName.equals("Finish")) {
            double grades = 0.0;

            for (int i = 1; i <= juryCount; i++) {
                grades += Double.parseDouble(scanner.nextLine());
            }
            sumAllGrades += grades;
            presentationsCount++;
            System.out.printf("%s - %.2f.%n", presentationName, grades / juryCount);

            presentationName = scanner.nextLine();
        }

        System.out.printf("Student's final assessment is %.2f.",
               sumAllGrades / (presentationsCount * juryCount));
    }
}
