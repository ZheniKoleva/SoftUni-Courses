import java.util.Scanner;

public class P05ChristmasGifts {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int kidsCount = 0;
        int adultsCount = 0;
        int toysCount = 0;
        int sweatersCount = 0;
        int toyPrice = 5;
        int sweaterPrice = 15;

        String command = scanner.nextLine();

        while (!command.equals("Christmas")) {
            int age = Integer.parseInt(command);

            if (age <= 16) {
                kidsCount++;
                toysCount++;

            } else {
                adultsCount++;
                sweatersCount++;
            }

            command = scanner.nextLine();

        }

        int toysTotalMoney = toysCount * toyPrice;
        int sweatersTotalMoney = sweatersCount * sweaterPrice;

        System.out.printf("Number of adults: %d\n"
                        + "Number of kids: %d\n"
                        + "Money for toys: %d\n"
                        + "Money for sweaters: %d",
                adultsCount, kidsCount, toysTotalMoney, sweatersTotalMoney);
    }
}
