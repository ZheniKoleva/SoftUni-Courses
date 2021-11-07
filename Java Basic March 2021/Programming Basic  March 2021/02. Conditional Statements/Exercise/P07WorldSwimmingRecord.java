package L02ConditionalStatements.Exercise;

import java.util.Scanner;

public class P07WorldSwimmingRecord {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        double worldRecord = Double.parseDouble(scanner.nextLine());
        double distanceToSwim = Double.parseDouble(scanner.nextLine());
        double timePerMeter = Double.parseDouble(scanner.nextLine());

        double timeSwim = distanceToSwim * timePerMeter;
        timeSwim += Math.floor(distanceToSwim /  15) * 12.5;
        double difference = timeSwim - worldRecord;

        if (timeSwim < worldRecord) {
            System.out.printf("Yes, he succeeded! The new world record is %.2f seconds.", timeSwim);
        }else {
            System.out.printf("No, he failed! He was %.2f seconds slower.", difference);
        }
    }
}
