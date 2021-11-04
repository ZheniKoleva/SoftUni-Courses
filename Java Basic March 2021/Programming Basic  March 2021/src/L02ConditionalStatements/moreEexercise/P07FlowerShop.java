package L02ConditionalStatements.MoreExercise;

import java.util.Scanner;

public class P07FlowerShop {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int magnoliaCount = Integer.parseInt(scanner.nextLine());
        int hyacinthCount = Integer.parseInt(scanner.nextLine());
        int roseCount = Integer.parseInt(scanner.nextLine());
        int cactusCount = Integer.parseInt(scanner.nextLine());
        double presentPrice = Double.parseDouble(scanner.nextLine());

        double magnoliaPrice = 3.25;
        double hyacinthPrice = 4.00;
        double rosePrice = 3.50;
        double cactusPrice = 8.00;

        double profit = (magnoliaCount * magnoliaPrice) + (hyacinthCount * hyacinthPrice) +
                (roseCount * rosePrice) + (cactusCount * cactusPrice);
        profit -= profit * 0.05;
        double difference = Math.abs(profit - presentPrice);

        if (profit >= presentPrice) {
            System.out.printf("She is left with %.0f leva.", Math.floor(difference));
        }else {
            System.out.printf("She will have to borrow %.0f leva.", Math.ceil(difference));
        }
    }
}
