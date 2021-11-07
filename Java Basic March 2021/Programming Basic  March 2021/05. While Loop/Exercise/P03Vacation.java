package L05WhileLoop.exercise;

import java.util.Scanner;

public class P03Vacation {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        double moneyNeeded = Double.parseDouble(scanner.nextLine());
        double moneyHave = Double.parseDouble(scanner.nextLine());

        int daysCount = 0;
        int spendDays = 0;
        boolean isFailed = false;

        while (moneyHave < moneyNeeded) {
            String command = scanner.nextLine();
            double currentMoney = Double.parseDouble(scanner.nextLine());
            daysCount++;

            switch (command) {
                case "save":
                    moneyHave += currentMoney;
                    spendDays = 0;
                    break;

                case "spend":
                    moneyHave -= currentMoney;
                    spendDays++;
                    if (moneyHave < 0) {
                        moneyHave = 0;
                    }
                    break;
            }

            if (spendDays == 5) {
                isFailed = true;
                break;
            }

        }

        if (isFailed) {
            System.out.printf("You can't save the money.%n" + "%d", daysCount);

        } else {
            System.out.printf("You saved the money for %d days.", daysCount);
        }
    }
}
