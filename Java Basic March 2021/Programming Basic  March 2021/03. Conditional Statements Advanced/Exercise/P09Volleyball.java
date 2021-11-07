package L03ConditionalStatementsAdvanced.exercise;

import java.util.Scanner;

public class P09Volleyball {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String yearTime = scanner.nextLine();
        int holidaysCount = Integer.parseInt(scanner.nextLine());
        int weekendsTravel = Integer.parseInt(scanner.nextLine());

        int weekendsSofia = 48 - weekendsTravel;
        double playsTotal = (weekendsSofia * 3.0 / 4) + (holidaysCount * 2.0 / 3) + weekendsTravel;
        if (yearTime.equals("leap")) {
            playsTotal += playsTotal * 0.15;
        }
        System.out.printf("%.0f", Math.floor(playsTotal));
    }
}
