package L04ForLoop.exercise;

import java.util.Scanner;

public class P06Salary {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int openTabs = Integer.parseInt(scanner.nextLine());
        int salary = Integer.parseInt(scanner.nextLine());

        int facebookFine = 150;
        int instagramFine = 100;
        int redditFine = 50;
        boolean hasLostSalary = false;

        for (int i = 0; i < openTabs; i++) {
            String siteName = scanner.nextLine().toLowerCase();

            switch (siteName) {
                case "facebook":
                    salary -= facebookFine;
                    break;
                case "instagram":
                    salary -= instagramFine;
                    break;
                case "reddit":
                    salary -= redditFine;
                    break;
            }

            if (salary <= 0) {
                hasLostSalary = true;
                break;
            }
        }
        if (hasLostSalary) {
            System.out.println("You have lost your salary.");
        }else {
            System.out.println(salary);
        }
    }
}
