import java.util.Scanner;

public class P03FinalCompetition {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int dancersCount = Integer.parseInt(scanner.nextLine());
        double points = Double.parseDouble(scanner.nextLine());
        String season = scanner.nextLine();
        String location = scanner.nextLine();

        double moneyEarned = dancersCount * points;
        double expenses = 0;

        switch (location) {
            case "Bulgaria":
                if (season.equals("summer")) {
                    expenses = 0.05;

                } else if (season.equals("winter")) {
                    expenses = 0.08;
                }
                break;

            case "Abroad":
                moneyEarned *= 1.50;
                if (season.equals("summer")) {
                    expenses = 0.10;

                } else if (season.equals("winter")) {
                    expenses = 0.15;
                }
                break;
        }

        moneyEarned -= moneyEarned * expenses;
        double charitySum = moneyEarned * 0.75;
        moneyEarned -= charitySum;
        double sumPerDancer = moneyEarned / dancersCount;

        System.out.printf("Charity - %.2f%n"
                        + "Money per dancer - %.2f",
                charitySum, sumPerDancer);
    }
}
