package L04ForLoop.moreExercise;

import java.util.Scanner;

public class P04Grades {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int studentsCount = Integer.parseInt(scanner.nextLine());

        int top = 0;
        int good = 0;
        int average = 0;
        int fail = 0;
        double gradesSum = 0.00;

        for (int i = 0; i < studentsCount; i++) {
            double grade = Double.parseDouble(scanner.nextLine());
            gradesSum += grade;

            if (grade < 3.00) {
                fail++;
            }else if (grade < 4.00) {
                average++;
            }else if (grade < 5.00) {
                good++;
            }else if (grade <= 6.00) {
                top++;
            }
        }
        System.out.printf("Top students: %.2f%%%n", (1.0 * top / studentsCount * 100));
        System.out.printf("Between 4.00 and 4.99: %.2f%%%n", (1.0 * good / studentsCount * 100));
        System.out.printf("Between 3.00 and 3.99: %.2f%%%n", (1.0 * average / studentsCount * 100));
        System.out.printf("Fail: %.2f%%%n", (1.0 * fail / studentsCount * 100));
        System.out.printf("Average: %.2f", gradesSum / studentsCount);
    }
}
