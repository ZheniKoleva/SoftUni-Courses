package L03ConditionalStatementsAdvanced.moreExercise;

import java.util.Scanner;

public class P02BikeRace {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int juniorCyclist = Integer.parseInt(scanner.nextLine());
        int seniorCyclist = Integer.parseInt(scanner.nextLine());
        String routeType = scanner.nextLine();

        int cyclistsCount = juniorCyclist + seniorCyclist;
        double juniorsTax = 0.00;
        double seniorsTax = 0.00;

        switch (routeType) {
            case "trail":
                juniorsTax = 5.50;
                seniorsTax = 7.00;
                break;
            case "cross-country":
                juniorsTax = 8.00;
                seniorsTax = 9.50;
                break;
            case "downhill":
                juniorsTax = 12.25;
                seniorsTax = 13.75;
                break;
            case "road":
                juniorsTax = 20.00;
                seniorsTax = 21.50;
                break;
        }

        double taxTotal = (juniorsTax * juniorCyclist) + (seniorsTax * seniorCyclist);

        if (cyclistsCount >= 50 && routeType.equals("cross-country")) {
            taxTotal -= taxTotal * 0.25;
        }

        taxTotal -= taxTotal * 0.05;

        System.out.printf("%.2f", taxTotal);

    }
}
