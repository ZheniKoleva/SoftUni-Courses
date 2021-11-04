import java.util.Scanner;

public class P06GoldMine {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int locationsCount = Integer.parseInt(scanner.nextLine());

        for (int i = 0; i < locationsCount; i++) {
            double expectedAvgYield = Double.parseDouble(scanner.nextLine());
            int daysCount = Integer.parseInt(scanner.nextLine());

            double yieldTotal = 0.0;

            for (int day = 1; day <= daysCount; day++) {
                yieldTotal += Double.parseDouble(scanner.nextLine());

            }

            double actualAvgYield = yieldTotal / daysCount;

            if (actualAvgYield >= expectedAvgYield) {
                System.out.printf("Good job! Average gold per day: %.2f.\n",
                        actualAvgYield);
            } else {
                System.out.printf("You need %.2f gold.\n",
                        expectedAvgYield - actualAvgYield);
            }
        }
    }
}
