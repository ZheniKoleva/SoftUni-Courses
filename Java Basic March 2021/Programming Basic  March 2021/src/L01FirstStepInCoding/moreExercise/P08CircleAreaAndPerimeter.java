package L01FirstStepInCoding.moreExercise;

import java.util.Scanner;

public class P08CircleAreaAndPerimeter {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        double radius = Double.parseDouble(scanner.nextLine());

        double area = Math.PI * Math.pow(radius, 2);
        double perimeter = radius * Math.PI * 2;

        System.out.printf("%.2f \n%.2f", area, perimeter);
    }
}
