package L01FirstStepInCoding.exercise;

import java.util.Scanner;

public class P06CharityCampaign {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int daysCount = Integer.parseInt(scanner.nextLine());
        int chefsCount = Integer.parseInt(scanner.nextLine());
        int cakesCount = Integer.parseInt(scanner.nextLine());
        int wafflesCount = Integer.parseInt(scanner.nextLine());
        int pancakesCount = Integer.parseInt(scanner.nextLine());

        double cakePrice = 45.00;
        double wafflePrice = 5.80;
        double pancakePrice = 3.20;

        double cakeProfit = cakePrice * cakesCount;
        double waffleProfit = wafflePrice * wafflesCount;
        double pancakeProfit = pancakePrice * pancakesCount;

        double profitsTotal = (cakeProfit + waffleProfit + pancakeProfit) * chefsCount * daysCount;
        profitsTotal -= profitsTotal / 8;

        System.out.printf("%.2f", profitsTotal);
    }
}
