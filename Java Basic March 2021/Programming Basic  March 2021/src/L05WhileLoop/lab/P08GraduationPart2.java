package L05WhileLoop.lab;

import java.util.Scanner;

public class P08GraduationPart2 {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String studentName = scanner.nextLine();

        double sumGrades = 0.0;
        int level = 1;
        int failed = 0;
        boolean isFailed = false;

        while (level <= 12) {
            double grade = Double.parseDouble(scanner.nextLine());

            if (grade < 4.00) {
                failed++;
                if (failed == 2) {
                    isFailed = true;
                    break;
                }

            }else {
                sumGrades += grade;
                level++;
            }
        }

        if (isFailed) {
            System.out.printf("%s has been excluded at %d grade", studentName, level);

        }else {
            double avgGrade = sumGrades / 12;
            System.out.printf("%s graduated. Average grade: %.2f", studentName, avgGrade);
        }
    }
}
