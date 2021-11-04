package L03ConditionalStatementsAdvanced.lab;

import java.util.Scanner;

public class P07WorkingHours {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int hour = Integer.parseInt(scanner.nextLine());
        String dayOfWeek = scanner.nextLine();

        boolean isOpen = hour >= 10 && hour <= 18;
        boolean isWorkingDay = !dayOfWeek.equals("Sunday");

        if (isOpen && isWorkingDay) {
            System.out.println("open");
        }else {
            System.out.println("closed");
        }

    }
}
