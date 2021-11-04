import java.util.Scanner;

public class P01Moon {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        double avgSpeed = Double.parseDouble(scanner.nextLine());
        double fuelPer100Km = Double.parseDouble(scanner.nextLine());

        int distance = 384400;
        int timeOnMoon = 3;

        int distanceTotal = distance * 2;
        double timeTotal = Math.ceil(distanceTotal / avgSpeed) + timeOnMoon;
        double fuelNeeded = (distanceTotal * fuelPer100Km) / 100;

        System.out.printf("%.0f\n" + "%.0f",  timeTotal, fuelNeeded);
    }
}
