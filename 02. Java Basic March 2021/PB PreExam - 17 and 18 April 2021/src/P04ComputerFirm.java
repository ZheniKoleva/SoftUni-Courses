import java.util.Scanner;

public class P04ComputerFirm {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int modelsCount = Integer.parseInt(scanner.nextLine());

        double sales = 0;
        int sumRatings = 0;

        for (int i = 0; i < modelsCount; i++) {
            int number = Integer.parseInt(scanner.nextLine());

            int currentRating = number % 10;
            double currentSales = Math.floor(number * 1.0 / 10);

            if (currentRating == 2) {
                currentSales = 0;

            } else if (currentRating == 3) {
                currentSales *= 0.50;

            } else if (currentRating == 4) {
                currentSales *= 0.70;

            } else if (currentRating == 5) {
                currentSales *= 0.85;

            } else if (currentRating == 6) {
                currentSales *= 1;

            }

            sales += currentSales;
            sumRatings += currentRating;
        }

        double avgRating = sumRatings * 1.0 / modelsCount;
        System.out.printf("%.2f%n" + "%.2f", sales, avgRating);
    }
}
