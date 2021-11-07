package L05WhileLoop.exercise;

import java.util.Scanner;

public class P02ExamPreparation {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int badGradesLimit = Integer.parseInt(scanner.nextLine());

        String lastTask = null;
        double sumGrades = 0.0;
        int tasksCount = 0;
        int failedCount = 0;
        boolean isFailed = false;

        String taskName = scanner.nextLine();

        while (!taskName.equals("Enough")) {
            double currentGrade = Double.parseDouble(scanner.nextLine());

            if (currentGrade <= 4.0) {
                failedCount++;

                if (failedCount == badGradesLimit) {
                    isFailed = true;
                    break;
                }
            }
            sumGrades += currentGrade;
            lastTask = taskName;
            tasksCount++;
            taskName = scanner.nextLine();
        }

        if (isFailed) {
            System.out.printf("You need a break, %d poor grades.", failedCount);

        } else {
            System.out.printf("Average score: %.2f%n"
                            + "Number of problems: %d%n"
                            + "Last problem: %s",
                    sumGrades / tasksCount, tasksCount, lastTask);
        }
    }
}
