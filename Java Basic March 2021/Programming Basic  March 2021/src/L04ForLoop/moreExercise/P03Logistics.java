package L04ForLoop.moreExercise;

import java.util.Scanner;

public class P03Logistics {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int cargoesCount = Integer.parseInt(scanner.nextLine());

        double microBusPrice = 200;
        double truckPrice = 175;
        double trainPrice = 120;
        double totalPrice = 0.00;
        int microBusWeight = 0;
        int truckWeight = 0;
        int trainWeight = 0;
        int totalWeight = 0;

        for (int i = 0; i < cargoesCount; i++) {
            int cargoWeight = Integer.parseInt(scanner.nextLine());
            totalWeight += cargoWeight;

            if (cargoWeight <= 3) {
                totalPrice += cargoWeight * microBusPrice;
                microBusWeight += cargoWeight;

            }else if (cargoWeight <= 11) {
                totalPrice += cargoWeight * truckPrice;
                truckWeight += cargoWeight;

            }else if (cargoWeight >= 12) {
                totalPrice += cargoWeight * trainPrice;
                trainWeight += cargoWeight;
            }
        }
        double averagePrice = totalPrice / totalWeight;
        double percentMicroBus = 1.0 * microBusWeight / totalWeight * 100;
        double percentTruck = 1.0 * truckWeight / totalWeight * 100;
        double percentTrain = 1.0 * trainWeight / totalWeight * 100;
        System.out.printf("%.2f%n" + "%.2f%%%n" + "%.2f%%%n" + "%.2f%%",
                averagePrice, percentMicroBus, percentTruck, percentTrain);
    }
}
