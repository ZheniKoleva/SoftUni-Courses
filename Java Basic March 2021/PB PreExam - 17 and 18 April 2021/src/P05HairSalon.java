import java.util.Scanner;

public class P05HairSalon {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int moneyToEarn = Integer.parseInt(scanner.nextLine());

        int moneyEarned = 0;
        boolean isReached = false;

        String serviceType = scanner.nextLine();
        while (!serviceType.equals("closed")) {

            String service = scanner.nextLine();

            switch (serviceType) {
                case "haircut":
                    if (service.equals("mens")) {
                        moneyEarned += 15;

                    } else if (service.equals("ladies")) {
                        moneyEarned += 20;

                    } else if (service.equals("kids")) {
                        moneyEarned += 10;
                    }
                    break;

                case "color":
                    if (service.equals("touch up")) {
                        moneyEarned += 20;

                    } else if (service.equals("full color")) {
                        moneyEarned += 30;
                    }
                    break;
            }

            if (moneyEarned >= moneyToEarn) {
                isReached = true;
                break;
            }

            serviceType = scanner.nextLine();
        }

        if (isReached) {
            System.out.println("You have reached your target for the day!");

        } else {
            int moneyNeeded = moneyToEarn - moneyEarned;
            System.out.printf("Target not reached! You need %dlv. more.%n", moneyNeeded);
        }

        System.out.printf("Earned money: %dlv.", moneyEarned);
    }
}
