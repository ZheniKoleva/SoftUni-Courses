package L01FirstStepInCoding.moreExercise;

import java.util.Scanner;

public class P03CelsiusToFahrenheit {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        double degreesCelsius = Double.parseDouble(scanner.nextLine());

        double degreesFahrenheit = (degreesCelsius * 9 /5) + 32;
        System.out.printf("%.2f", degreesFahrenheit);
    }
}
