package L02ConditionalStatements.Lab;

import java.util.Scanner;

public class P06AreaOfFigures {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String figureType = scanner.nextLine().toLowerCase();

        double area = 0.00;

        if (figureType.equals("square")) {
            double side = Double.parseDouble(scanner.nextLine());
            area = Math.pow(side, 2);
        } else if (figureType.equals("rectangle")) {
            double a = Double.parseDouble(scanner.nextLine());
            double b = Double.parseDouble(scanner.nextLine());
            area = a * b;
        } else if (figureType.equals("circle")) {
            double radius = Double.parseDouble(scanner.nextLine());
            area = Math.PI * Math.pow(radius, 2);
        }else if (figureType.equals("triangle")) {
            double side = Double.parseDouble(scanner.nextLine());
            double height = Double.parseDouble(scanner.nextLine());
            area = (side * height) / 2;
        }

        System.out.printf("%.3f", area);
    }
}
