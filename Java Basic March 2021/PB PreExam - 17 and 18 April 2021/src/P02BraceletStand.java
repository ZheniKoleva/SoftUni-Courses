import java.util.Scanner;

public class P02BraceletStand {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        double moneyPerDay = Double.parseDouble(scanner.nextLine());
        double moneyFromSales = Double.parseDouble(scanner.nextLine());
        double expenses = Double.parseDouble(scanner.nextLine());
        double presentPrice = Double.parseDouble(scanner.nextLine());

        int daysCount = 5;

        double totalMoneyEarned = (moneyPerDay + moneyFromSales) * daysCount;
        totalMoneyEarned -= expenses;

        if (totalMoneyEarned >= presentPrice) {
            System.out.printf("Profit: %.2f BGN, the gift has been purchased.", totalMoneyEarned);

        } else {
            double moneyNeeded = presentPrice - totalMoneyEarned;
            System.out.printf("Insufficient money: %.2f BGN.", moneyNeeded);
        }
    }
}
