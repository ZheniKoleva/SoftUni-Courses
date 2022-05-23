package L03ConditionalStatementsAdvanced.moreExercise;

import java.util.Scanner;

public class P08PointOnRectangleBorder {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        double x1 = Double.parseDouble(scanner.nextLine());
        double y1 = Double.parseDouble(scanner.nextLine());
        double x2 = Double.parseDouble(scanner.nextLine());
        double y2 = Double.parseDouble(scanner.nextLine());
        double x = Double.parseDouble(scanner.nextLine());
        double y = Double.parseDouble(scanner.nextLine());

        boolean isValidX = (x == x1 || x == x2) && (y >= y1 && y < y2);
        boolean isValidY = (y == y1 || y == y2) && (x >= x1 && x <= x2);

        if (isValidX || isValidY) {
            System.out.println("Border");

        }else {
            System.out.println("Inside / Outside");
        }
    }
}
