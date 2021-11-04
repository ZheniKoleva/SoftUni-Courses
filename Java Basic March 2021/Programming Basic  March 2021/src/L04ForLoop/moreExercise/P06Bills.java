package L04ForLoop.moreExercise;

import java.util.Scanner;

public class P06Bills {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int monthsCount = Integer.parseInt(scanner.nextLine());

        int waterTax = 20;
        int internetTax = 15;
        double electricityTotal = 0.00;
        double others = 0.00;
        double otherTotal = 0.00;
        double totalSum = 0.00;

        for (int i = 0; i < monthsCount; i++) {
            double electricity = Double.parseDouble(scanner.nextLine());
            electricityTotal += electricity;
            others = (waterTax + internetTax + electricity) * 1.20;
            otherTotal += others;
            totalSum += waterTax + internetTax + electricity + others;
        }

        System.out.printf("Electricity: %.2f lv %n" + "Water: %.2f lv %n"
                        + "Internet: %.2f lv %n" + "Other: %.2f lv %n"
                        + "Average: %.2f lv",
                electricityTotal, (1.0 * waterTax * monthsCount),
                (1.0 * internetTax * monthsCount), otherTotal, (totalSum / monthsCount));
    }
}
