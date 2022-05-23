package L02ConditionalStatements.Exercise;

import java.util.Scanner;

public class P08Scholarship {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        double income = Double.parseDouble(scanner.nextLine());
        double averageGrade = Double.parseDouble(scanner.nextLine());
        double minSalary = Double.parseDouble(scanner.nextLine());

        boolean hasSocial = (income < minSalary) && (averageGrade > 4.50);
        boolean hasExcellent = averageGrade >= 5.50;

        double social = Math.floor(minSalary * 0.35);
        double excellent = Math.floor(averageGrade * 25);

        if (!hasSocial && !hasExcellent) {
            System.out.println("You cannot get a scholarship!");
        }else if ((hasSocial && hasExcellent && social > excellent) || (hasSocial && !hasExcellent)) {
            System.out.printf("You get a Social scholarship %.0f BGN", social);
        }else if ((hasSocial && hasExcellent && social <= excellent) || (hasExcellent && !hasSocial)) {
            System.out.printf("You get a scholarship for excellent results %.0f BGN", excellent);
        }
    }
}
